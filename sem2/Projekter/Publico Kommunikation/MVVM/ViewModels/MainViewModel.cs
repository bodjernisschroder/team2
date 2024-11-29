using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly INavigationService _navigation;
        private readonly QuoteRepository _quoteRepository;
        private ViewModel _quoteView;
        private ViewModel _productsView;

        public ViewModel QuoteView
        {
            get => _quoteView;
            private set
            {
                if (_quoteView != value)
                {
                    _quoteView = value;
                    OnPropertyChanged(nameof(QuoteView));
                }
            }
        }

        public ViewModel ProductsView
        {
            get => _productsView;
            set
            {
                if (_productsView != value)
                {
                    _productsView = value;
                    OnPropertyChanged(nameof(ProductsView));
                }
            }
        }
        public RelayCommand ShowQuoteAndProductsCommand { get; }

        public MainViewModel(INavigationService navigation, QuoteRepository quoteRepository)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

            ShowQuoteAndProductsCommand = new RelayCommand(execute: o => { ShowQuoteAndProducts(); }, canExecute: o => true);
        }

        private void ShowQuoteAndProducts()
        {
            var quote = new Quote();
            _quoteRepository.Add(quote);
            QuoteView = _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteView as QuoteViewModel).OnSwitchRequested += Switch;

            ProductsView = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteView as QuoteViewModel); });
        }

        public void Switch(Quote quote)
        {
            (QuoteView as QuoteViewModel).OnSwitchRequested -= Switch;

            QuoteView = QuoteView.GetType() == typeof(SumQuoteViewModel)
                ? _navigation.NavigateTo<HourlyRateQuoteViewModel>(vm => { vm.InitializeQuote(quote); })
                : _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteView as QuoteViewModel).OnSwitchRequested += Switch;

            ProductsView = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteView as QuoteViewModel); });
        }
    }
}