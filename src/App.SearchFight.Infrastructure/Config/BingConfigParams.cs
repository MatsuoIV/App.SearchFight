using App.SearchFight.Utils.Constants;

namespace App.SearchFight.Infrastructure.Config
{
    class BingConfigParams : ConfigParams
    {
        public static string BaseUrl => GetConfigParams(ConfigConstants.BingBaseURL);
        public static string SuscriptionKey => GetConfigParams(ConfigConstants.BingSuscriptionKey);
        public static string ConfigurationId => GetConfigParams(ConfigConstants.BingConfigurationId);
    }
}
