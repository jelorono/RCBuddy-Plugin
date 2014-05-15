using System;

namespace RCBuddy.Classes
{
    public sealed class RCBDataHelper
    {
        private static RCBDataHelper _instance;

        public static RCBDataHelper Instance
        {
            get { return _instance ?? (_instance = new RCBDataHelper()); }
        }

        public string BotID { get; set; }

        public string CharName { get; set; }

        public int CharLevel { get; set; }

        public string CharZone { get; set; }

        public string CharRealm { get; set; }

        public int CharGold { get; set; }

        public int KillsTotal { get; set; }

        public float KillsHour { get; set; }

        public int Deaths { get; set; }

        public float DeathsHour { get; set; }

        public int BGsCompleted { get; set; }

        public int BGsLost { get; set; }

        public int BGsWon { get; set; }

        public float BGsHour { get; set; }

        public int HonorGained { get; set; }

        public float HonorHour { get; set; }

        public TimeSpan TimeToLevel { get; set; }

        public float XpHour { get; set; }

        public double UpTime { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}