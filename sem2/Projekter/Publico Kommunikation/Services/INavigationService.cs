using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    public interface INavigationService
    {
        ViewModel NavigateTo<TViewModel>(Action<TViewModel> initializer = null) where TViewModel : ViewModel;
    }
}