using System.Windows;
using Publico_Kommunikation_Project.MVVM.Views;
using Publico_Kommunikation_Project.MVVM.Models;
using Microsoft.Extensions.DependencyInjection;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.MVVM.ViewModels;
using Publico_Kommunikation_Project.DataAccess;
using Microsoft.Extensions.Configuration;

namespace Publico_Kommunikation_Project
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Load configuration
            var configuration = LoadConfiguration();
            services.AddSingleton(configuration);

            // Register services, repositories, ViewModels, and Views
            RegisterDatabase(services, configuration);
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterViewModels(services);
            RegisterViews(services);
        }

        private void RegisterDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton(connectionString);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<QuoteRepository>();
            services.AddScoped<QuoteProductRepository>();
        }

        private void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<MainViewModel>();
            services.AddTransient<HourlyRateQuoteViewModel>();
            services.AddScoped<ProductsViewModel>();
            services.AddScoped<ProductViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddTransient<SumQuoteViewModel>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
        }

        private void RegisterViews(IServiceCollection services)
        {
            services.AddSingleton(provider => new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }

        public IConfiguration LoadConfiguration()
        {
            // Use the ConfigurationBuilder to locate and load the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set base directory for the config file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add the JSON config file

            return builder.Build(); // Build and return the configuration object
        }

        // Override the OnStartup method, executed when the application starts
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainView>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}