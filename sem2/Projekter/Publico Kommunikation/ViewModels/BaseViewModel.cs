using System.ComponentModel;

namespace Publico_Kommunikation_Project.ViewModels
{
    // Implements INotifyPropertyChanged and can then be inherited by other ViewModels
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
