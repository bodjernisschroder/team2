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

            MessageBoxResult result = MessageBox.Show("Er du sikker på, at du vil oprette et nyt tilbud?", "Bekræft oprettelsen", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                MainContent.Content = new BudgetCreator();
            }

        }

        

        private void btnExitProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på, at du vil lukke programmet?", "Bekræft lukning", MessageBoxButton.OKCancel, MessageBoxImage.Question);


            if (result == MessageBoxResult.OK)
            {
                Close();
            }



        }

    }

}


