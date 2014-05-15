using System.IO;

using Styx;
using Styx.Common;
using Styx.Helpers;

namespace RCBuddy.Classes
{
    public sealed class RCBSettings : Settings
    {
        private static RCBSettings _instance;

        public static RCBSettings Instance
        {
            get { return _instance ?? (_instance = new RCBSettings()); }
        }

        public RCBSettings()
            : base(Path.Combine(Utilities.AssemblyDirectory, string.Format(@"Settings/RCBuddy/RCB-Settings-{0}.xml", StyxWoW.Me.Name)))
        {
        }

        [Setting, DefaultValue("")]
        public string ApiKey { get; set; }

        [Setting, DefaultValue(false)]
        public bool Privacy { get; set; }

        [Setting, DefaultValue(false)]
        public bool ScreenshotOnLvl { get; set; }
    }
}
