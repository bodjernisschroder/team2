using System.Windows.Input;

namespace Publico_Kommunikation_Project.Core
{
    /// <summary>
    /// Represents a command that can be bound to UI elements.
    /// Encapsulates the execution logic and condition. Implements the <see cref="ICommand"/> interface.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object>? _canExecute;

        /// <summary>
        /// Initializes a new instance of <see cref="RelayCommand"/> with the
        /// specified execution logic and condition.
        /// </summary>
        /// <param name="execute">The action to be executed.</param>
        /// <param name="canExecute">The predicate that determines whether the command can execute.</param>
        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// An event that automatically tracks changes in a command's executability
        /// using <see cref="CommandManager.RequerySuggested"/>.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Determines whether a command can currently execute.
        /// </summary>
        /// <param name="parameter">An optional parameter that determines whether the command can execute.
        /// If not specified, the execution state is determined by the current value of <see cref="_canExecute"/>.</param>
        /// <returns><c>true</c> if the command can execute, otherwise <c>false</c>.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command logic.
        /// </summary>
        /// <param name="parameter">An optional parameter that can be used during the execution of the command.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}