using System;
using System.Windows.Forms;
using System.IO.Compression;
using RCBuddy.Classes;
using RCBuddy.Forms;
using Styx.Common;
using Styx.CommonBot;
using Styx;
using Styx.Plugins;

namespace RCBuddy
{
    public class RCBuddy : HBPlugin
    {
        public static DateTime _startBot;
        public static DateTime _lastUpdate;

        public static bool UpToDate = true;

        public static readonly Version Revision = new Version(0, 0, 3);

        #region RCBuddy Overrides
        public override string Name
        {
            get { return "RCBuddy"; }
        }

        public override string Author
        {
            get { return "mcjambi & ikbeneenpeer"; }
        }

        public override Version Version
        {
            get { return Revision; }
        }

        public override bool WantButton
        {
            get { return true; }
        }

        public override void OnButtonPress()
        {
            new RCBSettingsForm().Show();
        }
        #endregion

        #region RCBuddy OnEnable
        public override void OnEnable()
        {
            base.OnEnable();

            BotEvents.OnBotStartRequested += OnBotStartHandler;
            BotEvents.OnBotStopped += OnBotStopHandler;

            RCBUpdater.Instance.CheckVersion();
        }
        #endregion

        #region RCBuddy OnDisable
        public override void OnDisable()
        {
            Log("Disabled");
            BotEvents.OnBotStartRequested -= OnBotStartHandler;
            BotEvents.OnBotStopped -= OnBotStopHandler;

            base.OnDisable();
        }
        #endregion

        #region RCBuddy BotStart
        public void OnBotStartHandler(EventArgs args)
        {
            _startBot = DateTime.Now;
            _lastUpdate = DateTime.Now;

            CheckApiKey();

            if (UpToDate) return;
            MessageBox.Show("We have updated your RCBuddy, please restart Honorbuddy!");
            return;
        }
        #endregion

        public static void CheckApiKey()
        {
            if (RCBDataHandler.Instance.PostData("validatekey", "http://rcbuddy.org/") == 200)
            {
                RCBUtilities.Instance.ValidKey = true;
                Log("Version " + Revision + " - Loaded");
                return;
            }
            MessageBox.Show(
                "Your API key seems to be invalid, please make sure you copied it properly of the website. \n\nRCBuddy will not function until fixed.");
        }

        #region RCBuddy BotStop
        public void OnBotStopHandler(EventArgs args)
        {

        }
        #endregion

        #region RCBuddy Pulse
        public override void Pulse()
        {
            if (!RCBUtilities.Instance.ValidKey) return;
            if (!StyxWoW.IsInGame || !StyxWoW.IsInWorld) return;
            if ((DateTime.Now - _lastUpdate).TotalSeconds < 10) return;
            Log("Sending data...");
            RCBDataHelper.Instance.UpTime = (DateTime.Now - _startBot).TotalSeconds;
            RCBUtilities.Instance.StartUpdate(BotManager.Current.Name);
            //RCBDataHandler.Instance.GetCommands("http://rcbuddy.org/");
            _lastUpdate = DateTime.Now;            
        }
        #endregion

        #region RCBuddy Methods
        #endregion

        #region RCBuddy Behaviors
        #endregion

        #region RCBuddy Logging
        public static void Log(string msg)
        {
            Logging.Write(System.Windows.Media.Colors.CadetBlue, "[RCBuddy] " + msg);
        }

        public static void Log(string msg, params object[] args)
        {
            Logging.Write(System.Windows.Media.Colors.CadetBlue, "[RCBuddy] " + msg, args);
        }

        public static void Log_err(string msg)
        {
            Logging.Write(System.Windows.Media.Colors.Red, "[Arena Cap] " + msg);
        }

        public static void Log_err(string msg, params object[] args)
        {
            Logging.Write(System.Windows.Media.Colors.Red, "[RCBuddy] " + msg, args);
        }
        #endregion
    }
}