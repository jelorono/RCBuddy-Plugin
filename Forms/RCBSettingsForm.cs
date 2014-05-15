using System;
using System.Windows.Forms;
using RCBuddy.Classes;

namespace RCBuddy.Forms
{
    public partial class RCBSettingsForm : Form
    {
        private const string SETTINGS_SAVED = "Settings succesfully saved.";

        public RCBSettingsForm()
        {
            InitializeComponent();
            RCBSettings.Instance.Load();

            apiKeyBox.Text = RCBSettings.Instance.ApiKey;
            privacyCheckBox.Checked = RCBSettings.Instance.Privacy;
            screenshotCheckBox.Checked = RCBSettings.Instance.ScreenshotOnLvl;
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            RCBSettings.Instance.ApiKey = apiKeyBox.Text;
            RCBSettings.Instance.Privacy = privacyCheckBox.Checked;
            RCBSettings.Instance.ScreenshotOnLvl = screenshotCheckBox.Checked;
            RCBSettings.Instance.Save();
            MessageBox.Show(SETTINGS_SAVED);
        }
    }
}
