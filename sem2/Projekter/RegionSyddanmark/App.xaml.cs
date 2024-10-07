using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.IO;

namespace RegionSyd
{
    public partial class App : Application
    {

        public IConfiguration Configuration { get; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

    }

}
