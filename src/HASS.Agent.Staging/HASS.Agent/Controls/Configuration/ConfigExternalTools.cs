﻿using System.Diagnostics;
using System.IO;
using HASS.Agent.Resources.Localization;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Configuration
{
    public partial class ConfigExternalTools : UserControl
    {
        public ConfigExternalTools()
        {
            InitializeComponent();
        }
        
        private void TbExternalBrowserBinary_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            // process selected browser
            ProcessSelectedBrowser(dialog.FileName);
        }

        /// <summary>
        /// Tries to determine what the incognito args & name are for the selected browser
        /// </summary>
        private void ProcessSelectedBrowser(string binary)
        {
            TbExternalBrowserBinary.Text = binary;

            var filename = Path.GetFileName(binary).ToLower();
            switch (filename)
            {
                case "chrome.exe":
                    TbExternalBrowserName.Text = "Chrome";
                    TbExternalBrowserIncognito.Text = "--incognito";
                    break;

                case "firefox.exe":
                    TbExternalBrowserName.Text = "Firefox";
                    TbExternalBrowserIncognito.Text = "-private-window";
                    break;

                case "vivaldi.exe":
                    TbExternalBrowserName.Text = "Vivaldi";
                    TbExternalBrowserIncognito.Text = "--incognito";
                    break;

                case "msedge.exe":
                    TbExternalBrowserName.Text = "Edge";
                    TbExternalBrowserIncognito.Text = "-inPrivate";
                    break;

                case "launcher" when binary.ToLower().Contains("opera"):
                    TbExternalBrowserName.Text = "Opera";
                    TbExternalBrowserIncognito.Text = "--private";
                    break;

                default:
                    TbExternalBrowserName.Text = Path.GetFileNameWithoutExtension(binary);
                    TbExternalBrowserIncognito.Text = string.Empty;
                    break;
            }
        }

        private void TbExternalExecutorBinary_DoubleClick(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            TbExternalExecutorBinary.Text = dialog.FileName;
            TbExternalExecutorName.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
        }

        private void BtnExternalBrowserIncognitoTest_Click(object sender, EventArgs e)
        {
            var browserBin = TbExternalBrowserBinary.Text.Trim();
            var incognitoArg = TbExternalBrowserIncognito.Text.Trim();

            if (string.IsNullOrEmpty(browserBin))
            {
                MessageBoxAdv.Show(Languages.ConfigExternalTools_BtnExternalBrowserIncognitoTest_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbExternalBrowserBinary;
                return;
            }

            if (!File.Exists(browserBin))
            {
                MessageBoxAdv.Show(Languages.ConfigExternalTools_ConfigExternalTools_BtnExternalBrowserIncognitoTest_MessageBox2, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbExternalBrowserBinary;
                return;
            }

            if (string.IsNullOrEmpty(incognitoArg))
            {
                var q = MessageBoxAdv.Show(Languages.ConfigExternalTools_BtnExternalBrowserIncognitoTest_MessageBox3, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q != DialogResult.Yes)
                {
                    ActiveControl = TbExternalBrowserBinary;
                    return;
                }
            }

            // lock ui
            BtnExternalBrowserIncognitoTest.Enabled = false;
            BtnExternalBrowserIncognitoTest.Text = "launching ..";

            try
            {
                using var testProc = new Process();
                var startupArgs = new ProcessStartInfo
                {
                    FileName = browserBin,
                    Arguments = !string.IsNullOrEmpty(incognitoArg) ? $"{incognitoArg} https://github.com/LAB02-Research/HASS.Agent" : "https://github.com/LAB02-Research/HASS.Agent"
                };

                testProc.StartInfo = startupArgs;
                testProc.Start();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BROWSER] Error testing for browser incognito mode: {err}", ex.Message);
                MessageBoxAdv.Show(Languages.ConfigExternalTools_BtnExternalBrowserIncognitoTest_MessageBox4, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // unlock ui
            BtnExternalBrowserIncognitoTest.Enabled = true;
            BtnExternalBrowserIncognitoTest.Text = "test";
        }
    }
}
