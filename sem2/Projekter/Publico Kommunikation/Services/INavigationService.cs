using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    /// <summary>
    /// An interface for navigation between ViewModel instances.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to a new instance of the specified <typeparamref name="TViewModel"/> type,
        /// optionally initializing it with the provided action.
        /// </summary>
        /// <typeparam name="TViewModel">The <see cref="ViewModel"/> to navigate to.</typeparam>
        /// <param name="initializer">An optional action to initialize the created <typeparamref name="TViewModel"/> instance.</param>
        /// <returns>The created <typeparamref name="TViewModel"/> instance, initialized if an action is provided.</returns>
        ViewModel NavigateTo<TViewModel>(Action<TViewModel> initializer = null) where TViewModel : ViewModel;
    }
}