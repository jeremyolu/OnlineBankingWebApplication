using System.Configuration;

namespace OnlineBanking.Data.Helpers
{
    public static class SqlHelper
    {
        public static string GetDatabase(string conn)
        {
            return ConfigurationManager.ConnectionStrings[conn].ConnectionString;
        }
    }
}
