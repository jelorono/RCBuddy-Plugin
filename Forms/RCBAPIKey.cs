using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RCBuddy.Classes;

namespace RCBuddy.Forms
{
    public partial class RCBAPIKey : Form
    {
        public RCBAPIKey()
        {
            InitializeComponent();

            RCBSettings.Instance.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RCBSettings.Instance.ApiKey = apiKeyBox.Text;
            RCBSettings.Instance.Save();
            RCBuddy.CheckApiKey();
            Close();
        }
    }
}
