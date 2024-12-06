using System.ComponentModel;

namespace Publico_Kommunikation.Core
{
    /// <summary>
    /// Serves as a base class for ViewModels. Implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event to notify subscribers
        /// that the property with the specified <paramref name="propertyName"/>
        /// has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
