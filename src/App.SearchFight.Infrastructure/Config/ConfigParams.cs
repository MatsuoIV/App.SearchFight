using System.Configuration;

namespace App.SearchFight.Infrastructure.Config
{
    public class ConfigParams
    {
        public static string GetConfigParams(string param)
        {
            return ConfigurationManager.AppSettings[param];
        }
    }
}
