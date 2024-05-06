using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace GettingReal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //private void btnYdelser_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new ProductCreator();
        //}

        private void btnTilbud_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new BudgetCreator();
        }

        private void btnExitProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
