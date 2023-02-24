using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton<LoginWindow>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ProductWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = serviceProvider.GetService<MainWindow>();
            loginWindow?.Show();   
        }
    }

    
}
