using Microsoft.Extensions.Configuration;
using System.Windows;
using Template.DataAccess;

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

            // Initialize the repository with the retrieved connection string
            var classTemplateRepository = new ClassTemplateRepository(connectionString);
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
