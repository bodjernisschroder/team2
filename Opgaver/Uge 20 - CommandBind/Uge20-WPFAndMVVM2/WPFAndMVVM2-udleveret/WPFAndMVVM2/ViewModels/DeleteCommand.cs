using System;
using System.Windows.Input;

namespace WPFAndMVVM2.ViewModels
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            // Opdaterer ændringer hurtigere, men koster mere computerkraft
            add { CommandManager.RequerySuggested += value; } 
            remove { CommandManager.RequerySuggested -= value; }  
        }

        public bool CanExecute(object parameter)
        {

            bool result = true;
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedPerson == null) 
                   result = false;
                
            }
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.DeleteSelectedPerson();
            }
        }
    }
}