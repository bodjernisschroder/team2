using Microsoft.Extensions.Configuration;
using System.Windows;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.ViewModels;
using Publico_Kommunikation_Project.Views;
using Microsoft.Extensions.DependencyInjection;
using Publico_Kommunikation_Project.Utilities;

namespace Publico_Kommunikation_Project
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            //Register singletons
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<ViewModelFactory>();

            //Register transients
            services.AddTransient<MainViewModel>();
            services.AddTransient<HourlyRateQuoteViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddTransient<SumQuoteViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        // Override the OnStartup method, executed when the application starts
        protected override void OnStartup(StartupEventArgs e)
        {
            // Load the configuration file and get the connection string
            var configuration = LoadConfiguration();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create all repos with connectionString as parameter
            var categoryRepository = new CategoryRepository(connectionString);
            var productRepository = new ProductRepository(connectionString);
            var quoteRepository = new QuoteRepository(connectionString);
            var quoteProductRepository = new QuoteProductRepository(connectionString);

            // Resolve MainViewModel through DI and set as DataContext for MainWindow
            var mainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainViewModel>()
            };
            mainWindow.Show();
            base.OnStartup(e);
        }

        // Method to load the configuration settings from appsettings.json
        private IConfiguration LoadConfiguration()
        {
            // Use the ConfigurationBuilder to locate and load the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set base directory for the config file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add the JSON config file

            return builder.Build(); // Build and return the configuration object
        }
    }
}
