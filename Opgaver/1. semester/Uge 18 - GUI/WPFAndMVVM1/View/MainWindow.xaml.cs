﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFAndMVVM1.ViewModel;

namespace WPFAndMVVM1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {

            InitializeComponent();

            DataContext = mvm;
        }

        private void btnUpdateLabel_Click(object sender, RoutedEventArgs e)
        {
            mvm.MyLabelText = DateTime.Now.ToString();
        }

        private void btnUpdateTextbox_Click(object sender, RoutedEventArgs e)
        {
            mvm.MyTextBoxText = DateTime.Now.ToString();
        }
    }
}