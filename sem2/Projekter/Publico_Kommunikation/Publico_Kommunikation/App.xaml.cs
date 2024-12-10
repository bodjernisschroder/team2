using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.MVVM.Views;
using Publico_Kommunikation_Project.MVVM.ViewModels;
using Publico_Kommunikation_Project.DataAccess;
using System.Collections.ObjectModel;

namespace Publico_Kommunikation_Project
{
    /// <summary>
    /// Acts as the entry point and core logic of the application.
    /// Inherits from the <see cref="Application"/> class, and manages the application's
    /// dependency injection setup, resource configuration, and startup logic.
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="App"/>. Sets up the application's
        /// dependency injection container and services. Executes automatically on application startup.
        /// </summary>
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Loads configuration and configures the specified <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        private void ConfigureServices(IServiceCollection services)
        {
            // Load configuration
            var configuration = LoadConfiguration();
            services.AddSingleton(configuration);

            // Register services, repositories, view models, and views
            RegisterDatabase(services, configuration);
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterViewModels(services);
            RegisterViews(services);
        }

        /// <summary>
        /// Registers the database connection string in the specified <paramref name="services"/> collection,
        /// using the specified <paramref name="configuration"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> that contains the database connection string.</param>
        private void RegisterDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("BurakConnection");
            services.AddSingleton(connectionString);
        }

        /// <summary>
        /// Registers application services in the specified <paramref name="services"/> collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
        }

        /// <summary>
        /// Registers repositories in the specified <paramref name="services"/> collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<QuoteRepository>();
            services.AddScoped<QuoteProductRepository>();
        }

        /// <summary>
        /// Registers view models in the specified <paramref name="services"/> collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        private void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<MainViewModel>();
            services.AddTransient<HourlyRateQuoteViewModel>();
            services.AddScoped<ProductsViewModel>();
            services.AddScoped<ProductViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddTransient<QuotesViewModel>();
            services.AddTransient<SumQuoteViewModel>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
        }

        /// <summary>
        /// Registers views in the specified <paramref name="services"/> collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        private void RegisterViews(IServiceCollection services)
        {
            services.AddSingleton(provider => new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }

        /// <summary>
        /// Initializes an <see cref="IConfiguration"/> instance with the settings
        /// from the appsettings.json file.
        /// </summary>
        /// <returns>The initialized <see cref="IConfiguration"/> instance.</returns>
        public IConfiguration LoadConfiguration()
        {
            // Use the ConfigurationBuilder to locate and load the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set base directory for the config file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add the JSON config file

            return builder.Build(); // Build and return the configuration object
        }

        /// <summary>
        /// Overrides the OnStartup method. Executes application startup logic.
        /// </summary>
        /// <param name="e">Provides information about the startup event, including command-line arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainView>();
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

            mainWindow.Show();

            if (mainViewModel.ShowQuoteOverviewCommand.CanExecute(null))
            {
                mainViewModel.ShowQuoteOverviewCommand.Execute(null);
            }

            base.OnStartup(e);
        }
    }
}