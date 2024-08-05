using DDD;
using Kernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;

namespace DotAgroN3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceCollection services = new();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            services.ConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();
            ServicesManager.Initialize(serviceProvider);
        }

        private void OnExit(object sender, ExitEventArgs e)
        {

        }
    }

}
