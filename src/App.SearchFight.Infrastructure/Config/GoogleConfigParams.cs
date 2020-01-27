using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.SearchFight.Infrastructure.Config
{
    public class GoogleConfigParams : ConfigParams
    {
        public static string BaseUrl => GetConfigParams("GoogleBaseURL");
        public static string ApiKey => GetConfigParams("GoogleAPIKey");
        public static string SearchId => GetConfigParams("GoogleSearchID");
    }
}
