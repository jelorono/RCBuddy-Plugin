using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

namespace RCBuddy.Classes
{
    public sealed class RCBDataHandler
    {
        private static RCBDataHandler _instance;

        public static RCBDataHandler Instance
        {
            get { return _instance ?? (_instance = new RCBDataHandler()); }
        }

        string DictToJSON(Dictionary<string, string> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }

        public Dictionary<string, string> GetStatusAsDict()
        {
            var statusdict = new Dictionary<string, string>();

            statusdict.Add("bot_id", RCBDataHelper.Instance.BotID);
            statusdict.Add("char_name", RCBDataHelper.Instance.CharName);
            statusdict.Add("char_level", RCBDataHelper.Instance.CharLevel.ToString());
            statusdict.Add("char_server", RCBDataHelper.Instance.CharRealm);
            statusdict.Add("char_zone", RCBDataHelper.Instance.CharZone);
            statusdict.Add("char_gold", RCBDataHelper.Instance.CharGold.ToString());
            statusdict.Add("kills_total", RCBDataHelper.Instance.KillsTotal.ToString());
            statusdict.Add("kills_hr", RCBDataHelper.Instance.KillsHour.ToString());
            //statusdict.Add("guild_gold", RCBDataHelper.Instance.GuildGold.ToString());
            statusdict.Add("uptime", RCBDataHelper.Instance.UpTime.ToString());
            statusdict.Add("deaths_total", RCBDataHelper.Instance.Deaths.ToString());
            statusdict.Add("deaths_hr", RCBDataHelper.Instance.DeathsHour.ToString());
            statusdict.Add("bg_completed", RCBDataHelper.Instance.BGsCompleted.ToString());
            statusdict.Add("bg_lost", RCBDataHelper.Instance.BGsLost.ToString());
            statusdict.Add("bg_won", RCBDataHelper.Instance.BGsWon.ToString());
            statusdict.Add("bg_hr", RCBDataHelper.Instance.BGsHour.ToString());
            statusdict.Add("honor_gained", RCBDataHelper.Instance.HonorGained.ToString());
            statusdict.Add("honor_hr", RCBDataHelper.Instance.HonorHour.ToString());
            statusdict.Add("time_to_level", RCBDataHelper.Instance.TimeToLevel.ToString());
            statusdict.Add("xp_hr", RCBDataHelper.Instance.XpHour.ToString());
            statusdict.Add("last_updated", RCBDataHelper.Instance.LastUpdated.ToString("u"));

            return statusdict;
        }

        public string GetCommands(string baseUrl)
        {
            RCBuddy.Log("gettings commands");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/get/command.php");
            httpWebRequest.ContentType = "text/html";
            httpWebRequest.Headers.Add("Api-Key", RCBSettings.Instance.ApiKey);
            httpWebRequest.Headers.Add("Bot-id", RCBDataHelper.Instance.BotID);
            httpWebRequest.Method = "GET";
            int StatusCode = 0;
            string results;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    results = streamReader.ReadToEnd();
                    string rc = httpResponse.Headers["Response-Text"];
                    RCBuddy.Log(results);
                    StatusCode = Convert.ToInt32(httpResponse.Headers["Status"]);
                }
            }

            return results;
        }

        public int PostData(string postType, string baseUrl, Dictionary<string, string> data = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/post/index.php");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Headers.Add("Api-Key", RCBSettings.Instance.ApiKey);
            httpWebRequest.Headers.Add("Post-Type", postType);
            httpWebRequest.Method = "POST";
            int StatusCode = 0;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                if (data != null)
                {
                    string json = DictToJSON(data);
                    //RCBuddy.Log(json);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    string rc = httpResponse.Headers["Response-Text"];
                    RCBuddy.Log(rc);
                    StatusCode = Convert.ToInt32(httpResponse.Headers["Status"]);
                }
            }

            return StatusCode;
        }
    }
}