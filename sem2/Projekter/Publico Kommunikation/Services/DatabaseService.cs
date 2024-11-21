// using Microsoft.Extensions.Configuration;
// using Publico_Kommunikation_Project.DataAccess;

// namespace Publico_Kommunikation_Project.Services
// {
//     public class DatabaseService
//     {
//         public void CreateRepositories()
//         {
//             // Load the configuration file and get the connection string
//             var configuration = LoadConfiguration();
//             string connectionString = configuration.GetConnectionString("DefaultConnection");

//             // Create all repos with connectionString as parameter
//             var categoryRepository = new CategoryRepository(connectionString);
//             var productRepository = new ProductRepository(connectionString);
//             var quoteRepository = new QuoteRepository(connectionString);
//             var quoteProductRepository = new QuoteProductRepository(connectionString);
//         }

//         //Method to load the configuration settings from appsettings.json
//         public IConfiguration LoadConfiguration()
//         {
//             // Use the ConfigurationBuilder to locate and load the appsettings.json file
//             var builder = new ConfigurationBuilder()
//                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set base directory for the config file
//                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add the JSON config file

//             return builder.Build(); // Build and return the configuration object
//         }
//     }
// }
