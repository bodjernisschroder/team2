using Microsoft.Extensions.Configuration;
using System.Windows;
using Template.DataAccess;
using Template.ViewModels;
using Template.Views;

namespace Template
{
    public partial class App : Application
    {
        // Override the OnStartup method, executed when the application starts
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load the configuration file and get the connection string
            var configuration = LoadConfiguration();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Initialize repositories with the retrieved connection string
            var classTemplateRepository = new ClassTemplateRepository(connectionString);

            // Pass repositories to ViewModels
            var mainViewModel = new MainViewModel(classTemplateRepository);

            // Set the DataContext or use mainViewModel as needed
            var mainWindow = new MainWindow { DataContext = mainViewModel };
            // mainWindow.Show();
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
