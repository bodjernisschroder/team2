using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFAndMVVM2.ViewModels
{
    public class NewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                //ListBox listBox = (ListBox)FindName("myListBox");
                mvm.AddDefaultPerson();
                //myListBox.ScrollIntoView(mvm.SelectedPerson);
                
            }

        }
    }
}