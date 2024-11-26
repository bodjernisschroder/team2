﻿using Publico_Kommunikation_Project.Core;
using System.Windows.Input;

namespace Publico_Kommunikation_Project.Core
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        //private Action showQuoteAndProducts;

        //public RelayCommand(Action showQuoteAndProducts)
        //{
        //    this.showQuoteAndProducts = showQuoteAndProducts;
        //}

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}