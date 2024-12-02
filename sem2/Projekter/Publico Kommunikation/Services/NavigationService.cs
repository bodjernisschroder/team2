using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    /// <summary>
    /// An implementation of the <see cref="INavigationService"/> interface.
    /// </summary>
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;

        /// <summary>
        /// Initializes a new instance of <see cref="NavigationService"/> with
        /// the specified <paramref name="viewModelFactory"/>.
        /// </summary>
        /// <param name="viewModelFactory">A function that takes a <see cref="Type"/> and returns an
        /// instance of <see cref="ViewModel"/>, used for invoking ViewModel instances.</param>
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