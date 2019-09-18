namespace AppMiTaller.Web.DA
{
    public static class DataBaseHelper
    {
        public static string GetDbConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["AppMiTallerCN"].ConnectionString;
        }
    }
}