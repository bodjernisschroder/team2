using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<FlowerSort> flowerSorts;
        public MainWindow()
        {
            InitializeComponent();
            flowerSorts = new List<FlowerSort>();
        }

        private void btnOpret_Click(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog popup = new CreateFlowerSortDialog();
            popup.ShowDialog();
        }

        //Skriver listen over alle de blomster, vi har tilføjet til programmet. 
        //public void UpdateFlowerList()
        //{
        //    string stringFlowerList;
        //    foreach (FlowerSort flower in flowerSorts)
        //    {
        //        stringFlowerList = $"Navn: {flower.Name} Billedsti: " +
        //            $"{flower.PicturePath} Production time: {flower.ProductionTime} " +
        //            $"Halveringstid: {flower.HalfLifeTime} Størrelse: {flower.Size}";

        //        txtFlowerList.Text = string.Join("\n", stringFlowerList);                
        //    }
        //}

        public void UpdateFlowerList()
        {
            if (flowerSorts.Count > 0)
            {
                string flowerListContent = string.Join("\n", flowerSorts.Select(f => f.ToString()));

                txtFlowerList.Text = flowerListContent;
            }
        }
    }
}