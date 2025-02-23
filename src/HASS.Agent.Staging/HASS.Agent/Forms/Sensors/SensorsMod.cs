﻿using System.Net.NetworkInformation;
using Syncfusion.Windows.Forms;
using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Sensors;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Extensions;
using HASS.Agent.Shared.Models.Config;
using Serilog;
using HASS.Agent.Shared.Functions;

namespace HASS.Agent.Forms.Sensors
{
    public partial class SensorsMod : MetroForm
    {
        internal readonly ConfiguredSensor Sensor;

        private readonly bool _serviceMode;
        private readonly string _serviceDeviceName;

        private bool _interfaceLockedWrongType;
        private bool _loading = true;

        private readonly Dictionary<string, string> _networkCards = new();

        private SensorType _selectedSensorType = SensorType.ActiveWindowSensor;

        public SensorsMod(ConfiguredSensor sensor, bool serviceMode = false, string serviceDeviceName = "")
        {
            Sensor = sensor;

            _serviceMode = serviceMode;
            _serviceDeviceName = serviceDeviceName;

            InitializeComponent();

            BindListViewTheme();

            BindComboBoxTheme();
        }

        public SensorsMod(bool serviceMode = false, string serviceDeviceName = "")
        {
            Sensor = new ConfiguredSensor();

            _serviceMode = serviceMode;
            _serviceDeviceName = serviceDeviceName;

            InitializeComponent();

            BindListViewTheme();

            BindComboBoxTheme();
        }

        private void BindListViewTheme()
        {
            LvSensors.DrawItem += ListViewTheme.DrawItem;
            LvSensors.DrawSubItem += ListViewTheme.DrawSubItem;
            LvSensors.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private void BindComboBoxTheme() => CbNetworkCard.DrawItem += ComboBoxTheme.DrawDictionaryStringStringItem;

        private void SensorMod_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // load sensors
            LvSensors.BeginUpdate();
            foreach (var sensor in SensorsManager.SensorInfoCards.Select(x => x.Value))
            {
                var lvSensor = new ListViewItem(sensor.Key.ToString());
                lvSensor.SubItems.Add(sensor.Name);
                lvSensor.SubItems.Add(sensor.MultiValue ? "√" : string.Empty);
                lvSensor.SubItems.Add(sensor.AgentCompatible ? "√" : string.Empty);
                lvSensor.SubItems.Add(sensor.SatelliteCompatible ? "√" : string.Empty);
                LvSensors.Items.Add(lvSensor);
            }
            LvSensors.EndUpdate();

            // load network cards
            _networkCards.Add("*", Languages.SensorsMod_All);
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces()) _networkCards.Add(nic.Id, nic.Name);

            // load in gui
            CbNetworkCard.DataSource = new BindingSource(_networkCards, null);

            // load or set sensor
            if (Sensor.Id == Guid.Empty)
            {
                Sensor.Id = Guid.NewGuid();
                Text = Languages.SensorsMod_Title_New;

                // done
                _loading = false;
                return;
            }

            // we're modding, load it
            LoadSensor();
            Text = Languages.SensorsMod_Title_Mod;

            // done
            _loading = false;
        }

        /// <summary>
        /// Loads the to-be-modded sensor
        /// </summary>
        private void LoadSensor()
        {
            // load the card
            var sensorCard = SensorsManager.SensorInfoCards[Sensor.Type];

            // set type
            _selectedSensorType = sensorCard.SensorType;

            // load the type
            TbSelectedType.Text = _selectedSensorType.ToString();

            // select it as well
            foreach (ListViewItem lvi in LvSensors.Items)
            {
                if (lvi.Text != sensorCard.Key.ToString()) continue;
                lvi.Selected = true;
                LvSensors.SelectedItems[0].EnsureVisible();
                break;
            }

            // set gui
            var guiOk = SetType(false);
            if (!guiOk) return;

            // set the name
            TbName.Text = Sensor.Name;
            if (!string.IsNullOrWhiteSpace(TbName.Text)) TbName.SelectionStart = TbName.Text.Length;

            // set interval
            NumInterval.Text = Sensor.UpdateInterval?.ToString() ?? "10";

            // set optional setting
            switch (_selectedSensorType)
            {
                case SensorType.NamedWindowSensor:
                    TbSetting1.Text = Sensor.WindowName;
                    break;

                case SensorType.WmiQuerySensor:
                    TbSetting1.Text = Sensor.Query;
                    TbSetting2.Text = Sensor.Scope;
                    break;

                case SensorType.PerformanceCounterSensor:
                    TbSetting1.Text = Sensor.Category;
                    TbSetting2.Text = Sensor.Counter;
                    TbSetting3.Text = Sensor.Instance;
                    break;

                case SensorType.ProcessActiveSensor:
                    TbSetting1.Text = Sensor.Query;
                    break;

                case SensorType.ServiceStateSensor:
                    TbSetting1.Text = Sensor.Query;
                    break;

                case SensorType.PowershellSensor:
                    TbSetting1.Text = Sensor.Query;
                    break;

                case SensorType.NetworkSensors:
                    if (_networkCards.ContainsKey(Sensor.Query)) CbNetworkCard.SelectedItem = new KeyValuePair<string, string>(Sensor.Query, _networkCards[Sensor.Query]);
                    break;

                case SensorType.WindowStateSensor:
                    TbSetting1.Text = Sensor.Query;
                    break;
            }
        }

        /// <summary>
        /// Change the UI depending on the selected type
        /// </summary>
        /// <param name="setDefaultValues"></param>
        private bool SetType(bool setDefaultValues = true)
        {
            if (LvSensors.SelectedItems.Count == 0)
            {
                // was the interface locked?
                if (_interfaceLockedWrongType) UnlockWrongClient();
                return false;
            }

            // find the sensor card
            var sensorId = int.Parse(LvSensors.SelectedItems[0].Text);
            var sensorCard = SensorsManager.SensorInfoCards.Where(card => card.Value.Key == sensorId)
                .Select(card => card.Value).FirstOrDefault();
            if (sensorCard == null) return false;

            // can the current client load this type?
            if (_serviceMode && !sensorCard.SatelliteCompatible)
            {
                LockWrongClient();
                return false;
            }

            if (!_serviceMode && !sensorCard.AgentCompatible)
            {
                LockWrongClient();
                return false;
            }

            // was the interface locked?
            if (_interfaceLockedWrongType) UnlockWrongClient();

            // set default values
            if (setDefaultValues)
            {
                TbName.Text = _serviceMode ? sensorCard.SensorType.GetSensorName(_serviceDeviceName) : sensorCard.SensorType.GetSensorName();
                NumInterval.Text = sensorCard.RefreshTimer.ToString();
                _selectedSensorType = sensorCard.SensorType;
            }

            TbSelectedType.Text = sensorCard.SensorType.ToString();
            TbDescription.Text = sensorCard.Description;
            
            // process the interface
            switch (sensorCard.SensorType)
            {
                case SensorType.NamedWindowSensor:
                    SetWindowGui();
                    break;

                case SensorType.WmiQuerySensor:
                    SetWmiGui();
                    break;

                case SensorType.PerformanceCounterSensor:
                    SetPerformanceCounterGui();
                    break;

                case SensorType.ProcessActiveSensor:
                    SetProcessGui();
                    break;

                case SensorType.ServiceStateSensor:
                    SetServiceStateGui();
                    break;

                case SensorType.NetworkSensors:
                    SetNetworkGui();
                    break;

                case SensorType.PowershellSensor:
                    SetPowershellGui();
                    break;

                case SensorType.WindowStateSensor:
                    SetProcessGui();
                    break;

                default:
                    SetEmptyGui();
                    break;
            }

            return true;
        }

        /// <summary>
        /// Change the UI to a 'named window' type
        /// </summary>
        private void SetWindowGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_WindowName;
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;

                BtnTest.Visible = false;
            }));
        }

        /// <summary>
        /// Change the UI to a 'wmi query' type
        /// </summary>
        private void SetWmiGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Wmi;
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;

                LblSetting2.Text = Languages.SensorsMod_LblSetting2_Wmi;
                LblSetting2.Visible = true;
                TbSetting2.Visible = true;

                BtnTest.Text = Languages.SensorsMod_BtnTest_Wmi;
                BtnTest.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'powershell command' type
        /// </summary>
        private void SetPowershellGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Powershell;
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;

                BtnTest.Text = Languages.SensorsMod_SensorsMod_BtnTest_Powershell;
                BtnTest.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'performance counter' type
        /// </summary>
        private void SetPerformanceCounterGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Category;
                LblSetting1.Visible = true;
                TbSetting1.Text = string.Empty;
                TbSetting1.Visible = true;

                LblSetting2.Text = Languages.SensorsMod_LblSetting2_Counter;
                LblSetting2.Visible = true;
                TbSetting2.Text = string.Empty;
                TbSetting2.Visible = true;

                LblSetting3.Text = Languages.SensorsMod_LblSetting3_Instance;
                LblSetting3.Visible = true;
                TbSetting3.Text = string.Empty;
                TbSetting3.Visible = true;

                BtnTest.Text = Languages.SensorsMod_BtnTest_PerformanceCounter;
                BtnTest.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'process active' type
        /// </summary>
        private void SetProcessGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Process;
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'service state' type
        /// </summary>
        private void SetServiceStateGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Service;
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'network' type
        /// </summary>
        private void SetNetworkGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = Languages.SensorsMod_LblSetting1_Network;
                LblSetting1.Visible = true;

                CbNetworkCard.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a general type
        /// </summary>
        private void SetEmptyGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting1.Visible = false;

                CbNetworkCard.Visible = false;

                TbSetting1.Text = string.Empty;
                TbSetting1.Visible = false;

                LblSetting2.Visible = false;
                TbSetting2.Text = string.Empty;
                TbSetting2.Visible = false;

                LblSetting3.Visible = false;
                TbSetting3.Text = string.Empty;
                TbSetting3.Visible = false;

                BtnTest.Visible = false;
            }));
        }
        
        private void LvSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            // set the ui to the selected type
            SetType();

            // set focus to the name field
            ActiveControl = TbName;
            if (!string.IsNullOrWhiteSpace(TbName.Text)) TbName.SelectionStart = TbName.Text.Length;
        }

        /// <summary>
        /// Prepare the sensor for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            if (LvSensors.SelectedItems.Count == 0)
            {
                MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get and check type
            var sensorId = int.Parse(LvSensors.SelectedItems[0].Text);
            var sensorCard = SensorsManager.SensorInfoCards.Where(card => card.Value.Key == sensorId)
                .Select(card => card.Value).FirstOrDefault();

            if (sensorCard == null)
            {
                MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get and check name
            var name = TbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox3, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbName;
                return;
            }

            // name contains illegal chars?
            var sanitized = SharedHelperFunctions.GetSafeValue(name);
            if (sanitized != name)
            {
                var confirmSanitize = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_MessageBox_Sanitize, sanitized), Variables.MessageBoxTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmSanitize != DialogResult.OK)
                {
                    ActiveControl = TbName;
                    return;
                }

                TbName.Text = sanitized;
                name = sanitized;
            }

            // name already used?
            if (!_serviceMode && Variables.SingleValueSensors.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Sensor.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox4, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            if (!_serviceMode && Variables.MultiValueSensors.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Sensor.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox5, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            // get and check update interval
            var interval = (int)NumInterval.Value;
            if (interval is < 1 or > 43200)
            {
                MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox6, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = NumInterval;
                return;
            }

            // check and set optional settings
            switch (sensorCard.SensorType)
            {
                case SensorType.NamedWindowSensor:
                    var window = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(window))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox7, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.WindowName = window;
                    break;

                case SensorType.WmiQuerySensor:
                    var query = TbSetting1.Text.Trim();
                    var scope = TbSetting2.Text.Trim();

                    // test the query
                    if (string.IsNullOrEmpty(query))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox8, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }

                    // test the scope
                    if (!string.IsNullOrEmpty(scope))
                    {
                        if (!HelperFunctions.CheckWmiScope(scope))
                        {
                            var scopeQ = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_WmiTestFailed, scope),
                                Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            if (scopeQ != DialogResult.Yes) return;
                        }
                    }

                    Sensor.Query = query;
                    Sensor.Scope = scope;
                    break;

                case SensorType.PerformanceCounterSensor:
                    var category = TbSetting1.Text.Trim();
                    var counter = TbSetting2.Text.Trim();
                    var instance = TbSetting3.Text.Trim();
                    if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(counter))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox9, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Category = category;
                    Sensor.Counter = counter;
                    Sensor.Instance = instance;
                    break;

                case SensorType.ProcessActiveSensor:
                    var process = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(process))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox10, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Query = process;
                    break;

                case SensorType.ServiceStateSensor:
                    var service = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(service))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox11, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Query = service;
                    break;

                case SensorType.NetworkSensors:
                    Sensor.Query = "*";
                    if (CbNetworkCard.SelectedItem != null)
                    {
                        var item = (KeyValuePair<string, string>)CbNetworkCard.SelectedItem;
                        Sensor.Query = item.Key;
                    }
                    break;

                case SensorType.PowershellSensor:
                    Sensor.Query = TbSetting1.Text.Trim();
                    break;

                case SensorType.WindowStateSensor:
                    var windowprocess = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(windowprocess))
                    {
                        MessageBoxAdv.Show(Languages.SensorsMod_BtnStore_MessageBox10, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Query = windowprocess;
                    break;
            }

            // set values
            Sensor.Type = sensorCard.SensorType;
            Sensor.Name = name;
            Sensor.UpdateInterval = interval;

            // done
            DialogResult = DialogResult.OK;
        }

        private void TbDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText)) return;
            if (!e.LinkText.ToLower().StartsWith("http")) return;

            HelperFunctions.LaunchUrl(e.LinkText);
        }

        private void SensorsMod_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvSensors.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void SensorsMod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void SensorsMod_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvSensors.Handle, ListViewTheme.SB_HORZ, false);
        }

        /// <summary>
        /// Locks the interface if the selected entity can't be added to the current client
        /// </summary>
        private void LockWrongClient()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LockWrongClient));
                return;
            }

            _interfaceLockedWrongType = true;

            var requiredClient = _serviceMode ? "hass.agent" : "service";
            LblSpecificClient.Text = string.Format(Languages.SensorsMod_SpecificClient, requiredClient);

            LblSpecificClient.Visible = true;

            TbName.Enabled = false;
            TbName.Text = string.Empty;

            SetEmptyGui();

            BtnStore.Enabled = false;
        }

        /// <summary>
        /// Unlocks the interface if the selected entity can be added to the current client
        /// </summary>
        private void UnlockWrongClient()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UnlockWrongClient));
                return;
            }

            _interfaceLockedWrongType = false;

            LblSpecificClient.Visible = false;

            TbName.Enabled = true;
            BtnStore.Enabled = true;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            switch (_selectedSensorType)
            {
                case SensorType.WmiQuerySensor:
                    TestWmi();
                    break;

                case SensorType.PerformanceCounterSensor:
                    TestPerformanceCounter();
                    break;

                case SensorType.PowershellSensor:
                    TestPowershell();
                    break;
            }
        }

        private async void TestWmi()
        {
            // prepare values
            var query = TbSetting1.Text.Trim();
            var scope = TbSetting2.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBoxAdv.Show(Languages.SensorsMod_TestWmi_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbSetting1;
                return;
            }

            // test the scope
            if (!string.IsNullOrEmpty(scope))
            {
                if (!HelperFunctions.CheckWmiScope(scope))
                {
                    var scopeQ = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_WmiTestFailed, scope),
                        Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (scopeQ != DialogResult.Yes) return;
                }
            }

            BtnTest.Enabled = false;

            // execute the test
            var result = await Task.Run(() => SensorTester.TestWmiQuery(query, scope));

            BtnTest.Enabled = true;

            if (result.Succesful)
            {
                MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestWmi_MessageBox2, result.ReturnValue), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // failed
            var q = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestWmi_MessageBox3, result.ErrorReason), Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (q != DialogResult.Yes) return;

            // open logs
            HelperFunctions.OpenLocalFolder(Variables.LogPath);
        }

        private async void TestPerformanceCounter()
        {
            // prepare values
            var category = TbSetting1.Text.Trim();
            var counter = TbSetting2.Text.Trim();
            var instance = TbSetting3.Text.Trim();

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(counter))
            {
                MessageBoxAdv.Show(Languages.SensorsMod_TestPerformanceCounter_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BtnTest.Enabled = false;

            // execute the test
            var result = await Task.Run((() => SensorTester.TestPerformanceCounter(category, counter, instance)));

            BtnTest.Enabled = true;

            if (result.Succesful)
            {
                MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestPerformanceCounter_MessageBox2, result.ReturnValue), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // failed
            var q = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestPerformanceCounter_MessageBox3, result.ErrorReason), Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (q != DialogResult.Yes) return;

            // open logs
            HelperFunctions.OpenLocalFolder(Variables.LogPath);
        }

        private async void TestPowershell()
        {
            // prepare values
            var command = TbSetting1.Text.Trim();

            if (string.IsNullOrEmpty(command))
            {
                MessageBoxAdv.Show(Languages.SensorsMod_TestPowershell_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BtnTest.Enabled = false;

            // execute the test
            var result = await Task.Run((() => SensorTester.TestPowershell(command)));

            BtnTest.Enabled = true;

            if (result.Succesful)
            {
                MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestPowershell_MessageBox2, result.ReturnValue), Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // failed
            var q = MessageBoxAdv.Show(string.Format(Languages.SensorsMod_TestPowershell_MessageBox3, result.ErrorReason), Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (q != DialogResult.Yes) return;

            // open logs
            HelperFunctions.OpenLocalFolder(Variables.LogPath);
        }
    }
}
