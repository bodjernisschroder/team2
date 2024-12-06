using System.Windows.Controls;
using System.Windows.Input;

namespace Publico_Kommunikation.MVVM.Views
{
    /// <summary>
    /// Interaction logic for QutoeView.xaml
    /// </summary>
    public partial class QuoteView : UserControl
    {
        public QuoteView()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Move focus to another control or clear focus
                Keyboard.ClearFocus();
            }
        }
    }
}
