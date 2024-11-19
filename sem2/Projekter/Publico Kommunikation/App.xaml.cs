using System.Windows;
using Publico_Kommunikation_Project.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.MVVM.ViewModels;

namespace Publico_Kommunikation_Project
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            //Register singletons
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<DatabaseService>();

            //Register transients
            services.AddTransient<MainViewModel>();
            services.AddTransient<HourlyRateQuoteViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddTransient<SumQuoteViewModel>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        // Override the OnStartup method, executed when the application starts
        protected override void OnStartup(StartupEventArgs e)
        {
            //DatabaseService dbService = new DatabaseService();
            //dbService.CreateRepositories();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}