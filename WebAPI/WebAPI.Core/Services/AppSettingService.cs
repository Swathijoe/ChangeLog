using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;


namespace WebAPI.Core.Services
{
    public sealed class AppSettingService :IAppSettingService
    {
        private readonly IConfiguration _configuration;
        private readonly string _AppSettingsConfigurationSection = "AppSettings";
        private IHostingEnvironment _hostingEnvironment;

        public AppSettingService(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;            
            _hostingEnvironment = environment;
            _ApiKey = GetKeyValue("API_KEY");
            _ApiKeyWrite = GetKeyValue("API_KEY_WRITE");
        }

        private string _ApiKey { get; set; }
        private string _ApiKeyWrite { get; set; }

        public string ApiKey { get { return _ApiKey; } }
        public string ApiKeyWrite { get { return _ApiKeyWrite; } }

        private string GetKeyValue(string key)
        {
            string keyFullPath = $"{_AppSettingsConfigurationSection}:{key}";
            return Convert.ToString(_configuration.GetSection(keyFullPath).AsEnumerable()
                         .Where(x => x.Key == keyFullPath)
                         .Select(s => s.Value).FirstOrDefault());

        }
    }
}
