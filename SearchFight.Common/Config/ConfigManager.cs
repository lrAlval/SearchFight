using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Common.Config
{
    public class ConfigManager
    {
        public static string GoogleUri => GetSettingByKey<string>("GoogleURL");
        public static string BingUri => GetSettingByKey<string>("BingURL");
        public static string GoogleKey => GetSettingByKey<string>("GoogleAPIKey");
        public static string GoogleCEKey => GetSettingByKey<string>("GoogleCEKey");
        public static string BingKey => GetSettingByKey<string>("BingKey");

        public static T GetSettingByKey<T>(string key, T defaultValue = default(T))
        {
            var value = ConfigurationManager.AppSettings[key];

            return string.IsNullOrWhiteSpace(value) ? defaultValue : (T)(object)(value);
        }
    }
}
