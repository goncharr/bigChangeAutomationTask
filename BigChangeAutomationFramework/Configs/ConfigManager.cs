using Microsoft.Extensions.Configuration;

namespace BigChangeAutomationFramework.AppConfiguration
{
    public static class ConfigManager
    {
        private static IConfiguration AppSetting { get; }
        public static IConfiguration Common { get; }
        
        static ConfigManager()
        {
            AppSetting = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("Configs/appsettings.json", optional: true, reloadOnChange: true)

                .Build();
            Common = AppSetting.GetSection("Common");
            
        }
    }
}
