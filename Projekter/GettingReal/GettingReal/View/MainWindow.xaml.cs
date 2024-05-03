using System.Windows;

namespace GettingReal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

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
