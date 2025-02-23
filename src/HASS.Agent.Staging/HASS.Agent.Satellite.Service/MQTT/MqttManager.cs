﻿using System.Diagnostics;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Models.HomeAssistant;
using HASS.Agent.Shared.Mqtt;
using HASS.Agent.Satellite.Service.Functions;
using HASS.Agent.Satellite.Service.Settings;
using MQTTnet;
using MQTTnet.Adapter;
using MQTTnet.Client;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Exceptions;
using MQTTnet.Extensions.ManagedClient;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HASS.Agent.Satellite.Service.MQTT
{
    /// <summary>
    /// Handles publishing and processing HASS entities (commands and sensors) through MQTT
    /// </summary>
    public class MqttManager : IMqttManager
    {
        private IManagedMqttClient? _mqttClient = null;

        private bool _disconnectionNotified = false;
        private bool _connectingFailureNotified = false;

        private MqttStatus _status = MqttStatus.Connecting;

        /// <summary>
        /// Returns whether the client is connected
        /// </summary>
        public bool IsConnected() => _mqttClient is { IsConnected: true };

        /// <summary>
        /// Returns whether the user wants the retain flag raised
        /// </summary>
        /// <returns></returns>
        public bool UseRetainFlag() => Variables.ServiceMqttSettings?.MqttUseRetainFlag ?? true;

        public Task SubscribeMediaCommandsAsync() => Task.CompletedTask;
        public Task SubscribeNotificationsAsync() => Task.CompletedTask;

        /// <summary>
        /// Returns the default or configured discovery prefix
        /// </summary>
        /// <returns></returns>
        public string MqttDiscoveryPrefix() => Variables.ServiceMqttSettings?.MqttDiscoveryPrefix ?? "homeassistant";

        /// <summary>
        /// Returns the device's config model
        /// </summary>
        /// <returns></returns>
        public DeviceConfigModel? GetDeviceConfigModel()
        {
            if (Variables.DeviceConfig != null) return Variables.DeviceConfig;
            
            CreateDeviceConfigModel();
            return Variables.DeviceConfig ?? null;
        }

        /// <summary>
        /// Initialize the MQTT manager, establish a connection
        /// </summary>
        public void Initialize()
        {
            try
            {
                // create our device's config model
                if (Variables.DeviceConfig == null) CreateDeviceConfigModel();

                // create a new mqtt client
                _mqttClient = Variables.MqttFactory.CreateManagedMqttClient();

                // bind 'connected' handler 
                _mqttClient.UseConnectedHandler(_ =>
                {
                    _status = MqttStatus.Connected;
                    Log.Information("[MQTT] Connected");

                    // reset error notifications 
                    _disconnectionNotified = false;
                    _connectingFailureNotified = false;
                });

                // bind 'connecting failed' handler
                _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(ConnectingFailedHandler);

                // bind 'messager received' handler
                _mqttClient.UseApplicationMessageReceivedHandler(e => HandleMessageReceived(e.ApplicationMessage));

                // bind 'disconnected' handler
                _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(DisconnectedHandler);

                // get the mqtt options
                var options = GetOptions();

                // only start connecting if they're found
                if (options == null)
                {
                    _status = MqttStatus.ConfigMissing;
                    Log.Warning("[MQTT] Configuration missing");
                    return;
                }

                Log.Information("[MQTT] Connecting ..");
                StartClient(options);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while initializing: {err}", ex.Message);
                _status = MqttStatus.Error;
            }
        }

        /// <summary>
        /// Creates a new MQTT client, using the current configuration
        /// </summary>
        public async void ReloadConfiguration()
        {
            try
            {
                Log.Information("[MQTT] Reloading configuration ..");

                // already connected?
                if (_mqttClient != null)
                {
                    // stop the connection
                    await _mqttClient.StopAsync();

                    // dispose our current client
                    _mqttClient.Dispose();
                    _mqttClient = null;
                }

                // clear our device config
                Variables.DeviceConfig = null;

                // reset state
                _status = MqttStatus.Connecting;
                _disconnectionNotified = false;
                _connectingFailureNotified = false;

                Log.Information("[MQTT] Initializing ..");

                // simple re-run initialization
                Initialize();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while reloading configuration: {err}", ex.Message);
                _status = MqttStatus.Error;
            }
        }

        /// <summary>
        /// Start and register a MQTT client with the provided options
        /// </summary>
        /// <param name="options"></param>
        private async void StartClient(IManagedMqttClientOptions options)
        {
            if (_mqttClient == null) return;

            try
            {
                // start the client
                await _mqttClient.StartAsync(options);

                // perform initial registration
                InitialRegistration();
            }
            catch (MqttConnectingFailedException ex)
            {
                Log.Error("[MQTT] Unable to connect to broker: {msg}", ex.Result.ToString());
            }
            catch (MqttCommunicationException ex)
            {
                Log.Error("[MQTT] Unable to communicate with broker: {msg}", ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("[MQTT] Exception while connecting with broker: {msg}", ex.ToString());
            }
        }

        /// <summary>
        /// Fires when connecting to the broker failed
        /// </summary>
        private async void ConnectingFailedHandler(ManagedProcessFailedEventArgs ex)
        {
            try
            {
                // give the connection the grace period to recover
                var runningTimer = Stopwatch.StartNew();
                while (runningTimer.Elapsed.TotalSeconds < Variables.ServiceSettings?.DisconnectedGracePeriodSeconds)
                {
                    if (_mqttClient is { IsConnected: true })
                    {
                        // recoved, nevermind
                        return;
                    }

                    await Task.Delay(TimeSpan.FromSeconds(5));
                }

                // nope, call it
                _status = MqttStatus.Error;

                // log only once
                if (_connectingFailureNotified) return;
                _connectingFailureNotified = true;

                Log.Fatal(ex.Exception, "[MQTT] Error while connecting: {err}", ex.Exception.Message);
            }
            catch (Exception exc)
            {
                Log.Error("[MQTT] Error while trying to handle failed connection: {msg}", exc.ToString());
            }
        }

        /// <summary>
        /// Fires when the client gets disconnected from the broker
        /// </summary>
        /// <param name="e"></param>
        private async void DisconnectedHandler(MqttClientDisconnectedEventArgs e)
        {
            try
            {
                // give the connection the grace period to recover
                var runningTimer = Stopwatch.StartNew();
                while (runningTimer.Elapsed.TotalSeconds < Variables.ServiceSettings?.DisconnectedGracePeriodSeconds)
                {
                    if (_mqttClient is { IsConnected: true })
                    {
                        // recoved, nevermind
                        return;
                    }

                    await Task.Delay(TimeSpan.FromSeconds(5));
                }

                // nope, call it
                _status = MqttStatus.Disconnected;

                // log if we're not shutting down
                if (Variables.ShuttingDown) return;

                // only once
                if (_disconnectionNotified) return;
                _disconnectionNotified = true;
            
                Log.Warning("[MQTT] Disconnected: {reason}", e.Reason.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("[MQTT] Error while trying to handle disconnection: {msg}", ex.ToString());
            }
        }

        /// <summary>
        /// Announce our availability
        /// <para>Deprecated: used to announce sensors/commands, now left to their managers</para>
        /// </summary>
        private async void InitialRegistration()
        {
            if (_mqttClient == null) return;
            while (!_mqttClient.IsConnected) await Task.Delay(2000);

            // let HA know we're here
            await AnnounceAvailabilityAsync();

            // done
            Log.Information("[MQTT] Initial registration completed");
        }

        /// <summary>
        /// Prepares info for the device we're running on
        /// </summary>
        public void CreateDeviceConfigModel()
        {
            var name = HelperFunctions.GetConfiguredDeviceName();
            Log.Information("[MQTT] Identifying as device: {name}", name);

            Variables.DeviceConfig = new DeviceConfigModel
            {
                Name = name,
                Identifiers = "hass.agent-" + name,
                Manufacturer = "LAB02 Research",
                Model = Environment.OSVersion.ToString(),
                Sw_version = Variables.Version
            };
        }

        private DateTime _lastPublishFailedLogged = DateTime.MinValue;
        /// <summary>
        /// Publishes the provided message
        /// </summary>
        public async Task PublishAsync(MqttApplicationMessage message)
        {
            try
            {
                if (_mqttClient is { IsConnected: true }) await _mqttClient.PublishAsync(message);
                else
                {
                    // only log failures once every 5 minutes to minimize log growth
                    if ((DateTime.Now - _lastPublishFailedLogged).TotalMinutes < 5) return;
                    _lastPublishFailedLogged = DateTime.Now;

                    Log.Warning("[MQTT] Not connected, message dropped (won't report again for 5 minutes)");
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while publishing: {err}", ex.Message);
            }
        }

        private DateTime _lastAutoDiscoConfigFailedLogged = DateTime.MinValue;
        /// <summary>
        /// Publish the provided autodiscovery config
        /// </summary>
        /// <param name="discoverable"></param>
        /// <param name="domain"></param>
        /// <param name="clearConfig"></param>
        /// <returns></returns>
        public async Task AnnounceAutoDiscoveryConfigAsync(AbstractDiscoverable discoverable, string domain, bool clearConfig = false)
        {
            if (_mqttClient is not { IsConnected: true }) return;

            try
            {
                if (Variables.DeviceConfig == null)
                {
                    // only log failures once every 5 minutes to minimize log growth
                    if ((DateTime.Now - _lastAutoDiscoConfigFailedLogged).TotalMinutes < 5) return;
                    _lastAutoDiscoConfigFailedLogged = DateTime.Now;

                    Log.Warning("[MQTT] Not connected, autodiscovery config dropped (won't report again for 5 minutes)");
                    return;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new CamelCaseJsonNamingpolicy(),
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                // prepare prefix
                if (string.IsNullOrEmpty(Variables.ServiceMqttSettings!.MqttDiscoveryPrefix)) Variables.ServiceMqttSettings.MqttDiscoveryPrefix = "homeassistant";

                // prepare topic
                var topic = $"{Variables.ServiceMqttSettings.MqttDiscoveryPrefix}/{domain}/{Variables.DeviceConfig.Name}/{discoverable.ObjectId}/config";

                // build config message
                var messageBuilder = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithRetainFlag(Variables.ServiceMqttSettings.MqttUseRetainFlag);

                // add payload
                if (clearConfig) messageBuilder.WithPayload(Array.Empty<byte>());
                else messageBuilder.WithPayload(JsonSerializer.Serialize(discoverable.GetAutoDiscoveryConfig(), discoverable.GetAutoDiscoveryConfig().GetType(), options));

                // publish disco config
                await PublishAsync(messageBuilder.Build());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while announcing autodiscovery: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Returns the status of the MQTT manager
        /// </summary>
        /// <returns></returns>
        public MqttStatus GetStatus() => _status;

        private DateTime _lastAvailableAnnouncement = DateTime.MinValue;
        private DateTime _lastAvailableAnnouncementFailedLogged = DateTime.MinValue;
        /// <summary>
        /// Announce our availability
        /// </summary>
        public async Task AnnounceAvailabilityAsync(bool offline = false)
        {
            if (_mqttClient is not { IsConnected: true }) return;

            try
            {
                // offline msgs always need to be sent, the rest once every 30 secs
                if (!offline)
                {
                    if ((DateTime.Now - _lastAvailableAnnouncement).TotalSeconds < 30) return;
                    _lastAvailableAnnouncement = DateTime.Now;
                }

                if (_mqttClient.IsConnected && Variables.DeviceConfig != null)
                {
                    if (string.IsNullOrEmpty(Variables.ServiceMqttSettings!.MqttDiscoveryPrefix)) Variables.ServiceMqttSettings.MqttDiscoveryPrefix = "homeassistant";

                    // prepare message
                    var messageBuilder = new MqttApplicationMessageBuilder()
                        .WithTopic($"{Variables.ServiceMqttSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                        .WithPayload(offline ? "offline" : "online")
                        .WithRetainFlag(Variables.ServiceMqttSettings.MqttUseRetainFlag);

                    // publish
                    await _mqttClient.PublishAsync(messageBuilder.Build());
                }
                else
                {
                    // only log failures once every 5 minutes to minimize log growth
                    if ((DateTime.Now - _lastAvailableAnnouncementFailedLogged).TotalMinutes < 5) return;
                    _lastAvailableAnnouncementFailedLogged = DateTime.Now;

                    Log.Warning(!_mqttClient.IsConnected
                        ? "[MQTT] Not connected, availability announcement dropped"
                        : "[MQTT] Device config not found, availability announcement dropped");
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while announcing availability: {err}", ex.Message);
            }
        }

        private DateTime _lastClearDeviceConfigFailedLogged = DateTime.MinValue;
        /// <summary>
        /// CLears the device config, removing the retained message
        /// </summary>
        /// <returns></returns>
        public async Task ClearDeviceConfigAsync()
        {
            if (_mqttClient is not { IsConnected: true })
            {
                Log.Warning("[MQTT] Not connected, clearing device config failed");
                return;
            }

            try
            {
                if (_mqttClient.IsConnected && Variables.DeviceConfig != null)
                {
                    if (string.IsNullOrEmpty(Variables.ServiceMqttSettings!.MqttDiscoveryPrefix)) Variables.ServiceMqttSettings.MqttDiscoveryPrefix = "homeassistant";

                    // prepare message
                    var messageBuilder = new MqttApplicationMessageBuilder()
                        .WithTopic($"{Variables.ServiceMqttSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                        .WithPayload(Array.Empty<byte>())
                        .WithRetainFlag(Variables.ServiceMqttSettings.MqttUseRetainFlag);

                    // publish
                    await _mqttClient.PublishAsync(messageBuilder.Build());
                }
                else
                {
                    // only log failures once every 5 minutes to minimize log growth
                    if ((DateTime.Now - _lastClearDeviceConfigFailedLogged).TotalMinutes < 5) return;
                    _lastClearDeviceConfigFailedLogged = DateTime.Now;

                    Log.Warning(!_mqttClient.IsConnected
                        ? "[MQTT] Not connected, clearing device config failed"
                        : "[MQTT] Device config not found, clearing device config failed");
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while clearing device config: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Disconnect from the broker (if connected)
        /// </summary>
        public void Disconnect()
        {
            if (_mqttClient == null) return;
            if (_mqttClient.IsConnected)
            {
                _mqttClient.InternalClient.DisconnectAsync();
                _mqttClient.Dispose();
            }

            Log.Information("[MQTT] Disconnected");
        }

        /// <summary>
        /// Subscribe to the provided command's topic
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(AbstractCommand command)
        {
            try
            {
                if (_mqttClient == null) return;
                if (!IsConnected()) while (IsConnected() == false) await Task.Delay(250);

                await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
                await _mqttClient.SubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Action_topic);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while subscribing: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Unsubscribe from the provided command's topic
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task UnubscribeAsync(AbstractCommand command)
        {
            try
            {
                if (_mqttClient == null) return;
                if (!IsConnected()) while (IsConnected() == false) await Task.Delay(250);

                await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Command_topic);
                await _mqttClient.UnsubscribeAsync(((CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig()).Action_topic);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while unsubscribing: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Prepare the required settings for a MQTT client
        /// </summary>
        /// <returns></returns>
        private static ManagedMqttClientOptions? GetOptions()
        {
            if (string.IsNullOrEmpty(Variables.ServiceMqttSettings?.MqttAddress)) return null;
            if (Variables.DeviceConfig == null) return null;

            // id can be random, but we'll store it for consistency (unless user-defined)
            if (string.IsNullOrEmpty(Variables.ServiceMqttSettings.MqttClientId))
            {
                Variables.ServiceMqttSettings.MqttClientId = Guid.NewGuid().ToString()[..8];
                SettingsManager.StoreServiceSettings();
            }

            // configure last will message
            var lastWillMessageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic($"{Variables.ServiceMqttSettings.MqttDiscoveryPrefix}/sensor/{Variables.DeviceConfig.Name}/availability")
                .WithPayload("offline")
                .WithRetainFlag(Variables.ServiceMqttSettings.MqttUseRetainFlag);

            // prepare message
            var lastWillMessage = lastWillMessageBuilder.Build();

            // basic options
            var clientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithClientId(Variables.ServiceMqttSettings.MqttClientId)
                .WithTcpServer(Variables.ServiceMqttSettings.MqttAddress, Variables.ServiceMqttSettings.MqttPort)
                .WithCleanSession()
                .WithWillMessage(lastWillMessage)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(15));

            // optional credentials
            if (!string.IsNullOrEmpty(Variables.ServiceMqttSettings.MqttUsername)) clientOptionsBuilder.WithCredentials(Variables.ServiceMqttSettings.MqttUsername, Variables.ServiceMqttSettings.MqttPassword);

            // configure tls
            var tlsParameters = new MqttClientOptionsBuilderTlsParameters()
            {
                UseTls = Variables.ServiceMqttSettings.MqttUseTls,
                AllowUntrustedCertificates = Variables.ServiceMqttSettings.MqttAllowUntrustedCertificates,
                SslProtocol = Variables.ServiceMqttSettings.MqttUseTls ? SslProtocols.Tls12 : SslProtocols.None
            };

            // configure certificates
            var certificates = new List<X509Certificate>();
            if (!string.IsNullOrEmpty(Variables.ServiceMqttSettings.MqttRootCertificate))
            {
                if (!File.Exists(Variables.ServiceMqttSettings.MqttRootCertificate)) Log.Error("[MQTT] Provided root certificate not found: {cert}", Variables.ServiceMqttSettings.MqttRootCertificate);
                else certificates.Add(new X509Certificate2(Variables.ServiceMqttSettings.MqttRootCertificate));
            }

            if (!string.IsNullOrEmpty(Variables.ServiceMqttSettings.MqttClientCertificate))
            {
                if (!File.Exists(Variables.ServiceMqttSettings.MqttClientCertificate)) Log.Error("[MQTT] Provided client certificate not found: {cert}", Variables.ServiceMqttSettings.MqttClientCertificate);
                certificates.Add(new X509Certificate2(Variables.ServiceMqttSettings.MqttClientCertificate));
            }

            // optionally loosen security
            if (Variables.ServiceMqttSettings.MqttAllowUntrustedCertificates)
            {
                tlsParameters.IgnoreCertificateChainErrors = true;
                tlsParameters.IgnoreCertificateRevocationErrors = true;
                tlsParameters.CertificateValidationHandler += _ => true;
            }

            // add the certs
            if (certificates.Count > 0) tlsParameters.Certificates = certificates;

            // finalise tls params
            clientOptionsBuilder.WithTls(tlsParameters);

            // build the client options
            clientOptionsBuilder.Build();

            // build and return the mqtt options
            return new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(clientOptionsBuilder).Build();
        }

        /// <summary>
        /// Handle incoming messages
        /// </summary>
        /// <param name="applicationMessage"></param>
        private static void HandleMessageReceived(MqttApplicationMessage applicationMessage)
        {
            try
            {
                if (!Variables.Commands.Any()) return;
                foreach (var command in Variables.Commands)
                {
                    var commandConfig = (CommandDiscoveryConfigModel)command.GetAutoDiscoveryConfig();

                    // check for command
                    if (commandConfig.Command_topic == applicationMessage.Topic) HandleCommandReceived(applicationMessage, command);

                    // check for action
                    else if (commandConfig.Action_topic == applicationMessage.Topic) HandleActionReceived(applicationMessage, command);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while handling received message: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Handles a command (on/off and variations)
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="command"></param>
        private static void HandleCommandReceived(MqttApplicationMessage applicationMessage, AbstractCommand command)
        {
            try
            {
                var payload = Encoding.UTF8.GetString(applicationMessage.Payload).ToLower();
                if (string.IsNullOrWhiteSpace(payload)) return;

                if (payload.Contains("on")) command.TurnOn();
                else if (payload.Contains("off")) command.TurnOff();
                else switch (payload)
                {
                    case "press":
                    case "lock":
                        command.TurnOn();
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while handling received command: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Handles an action (on + argument)
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="command"></param>
        private static void HandleActionReceived(MqttApplicationMessage applicationMessage, AbstractCommand command)
        {
            try
            {
                var payload = Encoding.UTF8.GetString(applicationMessage.Payload);
                if (string.IsNullOrWhiteSpace(payload)) return;

                command.TurnOnWithAction(payload);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[MQTT] Error while handling received action: {err}", ex.Message);
            }
        }
    }
}
