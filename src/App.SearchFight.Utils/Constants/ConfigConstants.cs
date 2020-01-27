using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.SearchFight.Utils.Constants
{
    public class ConfigConstants
    {
        ConfigConstants()
        {
        }

        #region Engine Data
        public static readonly string Google = "Google";
        public static readonly string Bing = "Bing";
        #endregion

        #region Config Keys

        public static readonly string GoogleBaseUrl = "GoogleBaseURL";
        public static readonly string GoogleAPIKey = "GoogleAPIKey";
        public static readonly string GoogleSearchID = "GoogleSearchID";
        public static readonly string BingBaseURL = "BingBaseURL";
        public static readonly string BingSuscriptionKey = "BingSuscriptionKey";
        public static readonly string BingConfigurationId = "BingConfigurationId";

        #endregion
    }
}
