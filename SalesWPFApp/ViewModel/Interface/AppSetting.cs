using Microsoft.Extensions.Configuration;
using System.IO;

namespace SalesWPFApp.ViewModel.Interface
{
    static class AppSetting
    {
        private static IConfigurationBuilder GetConfig()
        {
            return new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
        }

        public static IConfigurationSection GetAccount()
        {
            return GetConfig().Build().GetSection("account");
        }
    }
}
