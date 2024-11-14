using Publico_Kommunikation_Project.ViewModels;

namespace Publico_Kommunikation_Project.Utilities
{
    public class Navigator : INavigator
    {
        private readonly ViewModelFactory _viewModelFactory;
        public BaseViewModel CurrentViewModel { get; private set; }
        public Navigator(ViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<TViewModel>(object? param) where TViewModel : BaseViewModel
        {
            CurrentViewModel = _viewModelFactory.Create<TViewModel>(param);
        }
    }
}
