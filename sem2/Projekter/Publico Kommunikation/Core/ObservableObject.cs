using System.ComponentModel;

namespace Publico_Kommunikation_Project.Core
{
    // Implements INotifyPropertyChanged and can then be inherited by other ViewModels
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
