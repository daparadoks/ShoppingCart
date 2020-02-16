using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Api;
using ShoppingCart.Api.Config;

namespace ShoppingCart.Test
{
    public class TestStartUp
    {
        public TestStartUp()
        {
            var workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            const string environmentSpecificFileName = "appsettings.json";
            var configPath = $"{workingDirectory}{environmentSpecificFileName}";
            var builder = new ConfigurationBuilder()
                .AddJsonFile(configPath, true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            var applicationConfiguration = Configuration.GetSection("Application");
            services.Configure<ApplicationConfig>(applicationConfiguration);
            AddServices(services);
            ServiceProvider = services.AddLogging().BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; set; }

        public static IConfigurationRoot Configuration { get; set; }

        private static void AddServices(IServiceCollection services) =>
            Startup.AddServices(services, Configuration.GetConnectionString("ShoppingCart"));
    }
}