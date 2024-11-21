using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;

        //private ViewModel _currentView;

        //public ViewModel CurrentView
        //{
        //    get => _currentView;
        //    private set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged();
        //    }
        //}
        
        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public ViewModel NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            return _viewModelFactory.Invoke(typeof(TViewModel));
            //ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            //CurrentView = viewModel;
        }
    }
}