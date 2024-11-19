using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<ViewModel> NavigateToQuoteViewCommand { get; set; }
        public RelayCommand<ViewModel> NavigateToProductsViewCommand { get; set; }

        public MainViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToQuoteViewCommand = new RelayCommand<ViewModel>(execute: o => { Navigation.NavigateTo<QuoteViewModel>(); }, canExecute: o => true);
            NavigateToProductsViewCommand = new RelayCommand<ViewModel>(execute: o => { Navigation.NavigateTo<ProductsViewModel>(); }, canExecute: o => true);
        }
    }
}