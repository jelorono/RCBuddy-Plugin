using System;
using System.Diagnostics;
using System.Threading;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;

namespace RCBuddy.Classes
{
    public sealed class RCBUtilities
    {
        private static RCBUtilities _instance;

        public static RCBUtilities Instance
        {
            get { return _instance ?? (_instance = new RCBUtilities()); }
        }

        public bool ValidKey = false;

        private readonly LocalPlayer _me = StyxWoW.Me;

        public void StartUpdate(string botBase)
        {
            new Thread(delegate()
            {
                Update(botBase);
            }).Start();
        }

        public void Update(string botBase)
        {
            RCBDataHelper.Instance.BotID = GetBotID(RCBSettings.Instance.ApiKey, _me.Name, _me.RealmName);
            if (RCBSettings.Instance.Privacy)
            {
                RCBDataHelper.Instance.CharName = RCBDataHelper.Instance.BotID;
            }
            else
            {
                RCBDataHelper.Instance.CharName = _me.Name;
            }

            RCBDataHelper.Instance.UpTime = (DateTime.Now - RCBuddy._startBot).TotalSeconds;
            RCBDataHelper.Instance.CharLevel = _me.Level;
            RCBDataHelper.Instance.CharZone = _me.ZoneText;
            RCBDataHelper.Instance.CharRealm = _me.RealmName;
            RCBDataHelper.Instance.LastUpdated = DateTime.Now;
            RCBDataHelper.Instance.CharGold = Convert.ToInt32(_me.Copper);
            RCBDataHelper.Instance.Deaths = Convert.ToInt32(GameStats.Deaths);
            RCBDataHelper.Instance.DeathsHour = GameStats.DeathsPerHour;

            switch (botBase)
            {
                case ("BGBot"):
                case ("BGBuddy"):
                    RCBDataHelper.Instance.BGsCompleted = Convert.ToInt32(GameStats.BGsCompleted);
                    RCBDataHelper.Instance.BGsWon = Convert.ToInt32(GameStats.BGsWon);
                    RCBDataHelper.Instance.BGsLost = Convert.ToInt32(GameStats.BGsLost);
                    RCBDataHelper.Instance.BGsHour = GameStats.BGsPerHour;
                    break;
                case ("Questing"):
                case ("[BETA] GrindBuddy"):
                case ("Grind Bot"):
                    RCBDataHelper.Instance.KillsHour = Convert.ToInt32(GameStats.MobsPerHour);
                    RCBDataHelper.Instance.KillsTotal = Convert.ToInt32(GameStats.MobsKilled);
                    if (_me.Level < 90)
                    {
                        RCBDataHelper.Instance.TimeToLevel = GameStats.TimeToLevel;
                        RCBDataHelper.Instance.XpHour = GameStats.XPPerHour;
                    }
                    break;
            }

            var result = RCBDataHandler.Instance.PostData("status", "http://rcbuddy.org/", RCBDataHandler.Instance.GetStatusAsDict());

            if (result == 401 || result == 402)
            {
                ValidKey = false;
                //return false;
            }
            else if (result != 200)
            {
                //return false;
            }
            ValidKey = true;
            //return true;
        }

        private static Thread _bgThread;

        public void ExecuteCommand(string command)
        {
            _bgThread.Start();
            switch (command)
            {
                case ("start"):
                    TreeRoot.Start();
                    _bgThread.Abort();
                    break;
                case ("stop"):
                    TreeRoot.Stop();
                    break;
                /*case ("changeprofile"):
                    Styx.CommonBot.TreeRoot.Stop();
                    Styx.CommonBot.Profiles.ProfileManager.LoadNew("REPLACE");
                    Styx.CommonBot.TreeRoot.Start();
                    break;*/
                case ("killrelogger"):
                    foreach (Process proc in Process.GetProcessesByName("HBRelog"))
                    {
                        proc.Kill();
                    }
                    foreach (Process proc in Process.GetProcessesByName("ARelog"))
                    {
                        proc.Kill();
                    }
                    _bgThread.Abort();
                    break;
                case ("killwow"):
                    foreach (Process proc in Process.GetProcessesByName("Wow"))
                    {
                        proc.Kill();
                    }
                    _bgThread.Abort();
                    break;

            }
        }

        #region RCBuddy botID
        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public string GetBotID(string apiKey, string charName, string charRealm)
        {
            var botID = CalculateMD5Hash(apiKey + charName + charRealm);
            botID = botID.Substring(0, 12);

            return botID;
        }
        #endregion
    }
}
