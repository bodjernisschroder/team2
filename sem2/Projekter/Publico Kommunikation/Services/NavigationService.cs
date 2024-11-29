using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public ViewModel NavigateTo<TViewModel>(Action<TViewModel> initializer = null) where TViewModel : ViewModel
        {
            var viewModel = _viewModelFactory.Invoke(typeof(TViewModel)) as TViewModel;
            initializer?.Invoke(viewModel);
            return viewModel;
        }
    }
}