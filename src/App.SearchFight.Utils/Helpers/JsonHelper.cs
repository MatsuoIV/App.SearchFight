using System.Web.Script.Serialization;

namespace App.SearchFight.Utils.Helpers
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(string json)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }
    }
}
