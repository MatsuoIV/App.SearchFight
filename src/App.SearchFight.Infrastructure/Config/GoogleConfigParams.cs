using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Utils.Constants;

namespace App.SearchFight.Infrastructure.Config
{
    public class GoogleConfigParams : ConfigParams
    {
        public static string BaseUrl => GetConfigParams(ConfigConstants.GoogleBaseUrl);
        public static string ApiKey => GetConfigParams(ConfigConstants.GoogleAPIKey);
        public static string SearchId => GetConfigParams(ConfigConstants.GoogleSearchID);
    }
}
