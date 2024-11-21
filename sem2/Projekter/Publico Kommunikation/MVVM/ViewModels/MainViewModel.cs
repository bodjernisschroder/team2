using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private INavigationService _navigation;
        //public INavigationService Navigation
        //{
        //    get => _navigation;
        //    set
        //    {
        //        _navigation = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ViewModel QuoteView { get; private set; }
        public ViewModel ProductsView { get; private set; }

        public RelayCommand ShowQuoteAndProductsCommand { get; }

        //public RelayCommand NavigateToQuoteViewCommand { get; set; }
        //public RelayCommand NavigateToProductsViewCommand { get; set; }

        public MainViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            //NavigateToQuoteViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<QuoteViewModel>(); }, canExecute: o => true);
            //NavigateToProductsViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ProductsViewModel>(); }, canExecute: o => true);
            ShowQuoteAndProductsCommand = new RelayCommand(execute: o => { ShowQuoteAndProducts(); }, canExecute: o => true);
        }
        
        private void ShowQuoteAndProducts()
        {
            QuoteView = _navigation.NavigateTo<QuoteViewModel>();
            ProductsView = _navigation.NavigateTo<ProductsViewModel>();

            OnPropertyChanged(nameof(QuoteView));
            OnPropertyChanged(nameof(ProductsView));
        }
    }
}