using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
