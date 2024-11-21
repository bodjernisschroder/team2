using Publico_Kommunikation_Project.Core;

namespace Publico_Kommunikation_Project.Services
{
    public interface INavigationService
    {
        //ViewModel CurrentView { get; }

        // Adskiller sig fra videoen ved at tage en param, så vi kan tage
        // en Quote til QuoteViewModel f.eks.

        //void NavigateTo<TViewModel>() where TViewModel : ViewModel;

        ViewModel NavigateTo<TViewModel>() where TViewModel : ViewModel;
    }
}