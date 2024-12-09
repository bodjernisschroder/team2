using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.Services;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;
using Publico_Kommunikation.MVVM.Views;

namespace Publico_Kommunikation
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
            string connectionString = configuration.GetConnectionString("AnnaConnection");
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
            services.AddScoped<ISimpleKeyRepository<Category>, CategoryRepository>();
            services.AddScoped<ISimpleKeyRepository<Product>, ProductRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<ICompositeKeyRepository<QuoteProduct>, QuoteProductRepository>();
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
        /// Overrides the OnStartup method to execute application startup logic.
        /// Shows <see cref="MainView"/> and sets up error handling for unhandled exceptions.
        /// In case of unhandled exceptions, logs the error and displays a <see cref="MessageBox"/> to notify the user.
        /// </summary>
        /// <param name="e">Provides information about the startup event, including command-line arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainView>();
            mainWindow.Show();
            base.OnStartup(e);
            
            // Global exception handler for non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception e = (Exception)args.ExceptionObject;
                LogError(e);
                MessageBox.Show("Der skete en uventet fejl. Programmet Lukkes", "Uventet fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                ShutdownApplication();
            };

            // Global exception handler for UI thread exceptions
            DispatcherUnhandledException += (sender, args) =>
            {
                LogError(args.Exception);
                MessageBox.Show("Der skete en uventet fejl. Prøv igen. \nHvis problemet fortsætter, genstart programmet.", "UI-fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                args.Handled = true;
            };
        }

        /// <summary>
        /// Logs the error specified by <paramref name="e"/>.
        /// </summary>
        /// <param name="e"></param>
        private void LogError(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            Console.WriteLine($"Stack Trace: {e.StackTrace}");
        }

        /// <summary>
        /// Shuts down the application if it is currently running.
        /// If the application instance is unavailable, forces the process to terminate.
        /// </summary>
        private void ShutdownApplication()
        {
            if (Application.Current != null)
                Application.Current.Shutdown();
            else
                Environment.Exit(1);
        }
    }
}