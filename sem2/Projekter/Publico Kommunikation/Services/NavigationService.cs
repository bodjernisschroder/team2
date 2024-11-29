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

        /// <summary>
        /// Navigates to a new instance of the specified <typeparamref name="TViewModel"/> type,
        /// optionally initializing it with the provided action.
        /// </summary>
        /// <typeparam name="TViewModel">The <see cref="ViewModel"/> to navigate to.</typeparam>
        /// <param name="initializer">An optional action to initialize the created <typeparamref name="TViewModel"/> instance.</param>
        /// <returns>The created <typeparamref name="TViewModel"/> instance, initialized if an action is provided.</returns>
        public ViewModel NavigateTo<TViewModel>(Action<TViewModel> initializer = null) where TViewModel : ViewModel
        {
            var viewModel = _viewModelFactory.Invoke(typeof(TViewModel)) as TViewModel;
            initializer?.Invoke(viewModel);
            return viewModel;
        }
    }
}