using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Styx.Common;

namespace RCBuddy.Classes
{
    public sealed class RCBUpdater
    {
        private static RCBUpdater _instance;

        public static RCBUpdater Instance
        {
            get { return _instance ?? (_instance = new RCBUpdater()); }
        }

        public void CheckVersion()
        {
            RCBuddy.Log(
                "Checking if there is a newer version of RCBuddy available.");

            var wClient = new WebClient();
            var strSource = wClient.DownloadString("http://rcbuddy.googlecode.com/svn/trunk/version.txt");
            var v = new Version(strSource);

            if (RCBuddy.Revision < v)
            {
                RCBuddy.Log(
                    "There's a new version available. \n" +
                    "[RCBuddy] Newest Version: {0} \n" +
                    "[RCBuddy] Auto updating your plugin now.",
                    strSource);
                RCBuddy.UpToDate = false;
                UpdateRcb(v);
                return;
            }

            RCBuddy.Log(
                "Your version is up-to-date. RCBuddy will proceed as usual.");
        }

        public void UpdateRcb(Version version)
        {
            var url = "http://rcbuddy.googlecode.com/svn/trunk/";
            var loc = Path.Combine(Utilities.AssemblyDirectory, (@"Plugins/RCBuddy/"));

            RCBuddy.Log(
                "Downloading newest version of SVN.. \n" +
                "[RCBuddy] ------------------------------------------------");

            DownloadUpdate(url, loc);
        }

        public static void DownloadUpdate(string url, string loc)
        {
            var client = new WebClient();

            XDocument xConfig = XDocument.Load(url + "updateinfo.xml");

            foreach (var node in xConfig.Element("updater").Element("updatedfiles").Elements("rcb"))
            {
                RCBuddy.Log("Downloading file - {0}", node.Value);
                if (node.Value.Contains("\\"))
                {
                    if (!Directory.Exists(loc + node.Value.Substring(0, node.Value.IndexOf("\\"))))
                        Directory.CreateDirectory(loc + node.Value.Substring(0, node.Value.IndexOf("\\")));
                }
                client.DownloadFile(url + node.Value.Replace('\\', '/'), loc + node.Value);
            }

            RCBuddy.Log("------------------------------------------------ \n" +
                "[RCBuddy] Finished downloading all files. Please restart Honorbuddy for RCBuddy to be fully functional.");
        }
    }
}
