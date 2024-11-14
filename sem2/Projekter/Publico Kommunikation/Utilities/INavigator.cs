using Publico_Kommunikation_Project.ViewModels;

namespace Publico_Kommunikation_Project.Utilities
{
    public interface INavigator
    {
        void NavigateTo<TViewModel>(object? param) where TViewModel : BaseViewModel;
    }
}
