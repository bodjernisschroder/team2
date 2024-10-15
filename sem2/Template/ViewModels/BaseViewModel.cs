using System.ComponentModel;

namespace Template.ViewModels
{
    // Implements INotifyPropertyChanged and can then be inherited by other ViewModels
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
