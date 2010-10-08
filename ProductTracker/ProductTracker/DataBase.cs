using System.Configuration;

namespace ProductTracker
{
    public static class DataBase
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}