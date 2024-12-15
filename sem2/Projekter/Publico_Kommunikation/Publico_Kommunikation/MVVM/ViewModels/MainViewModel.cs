using Publico_Kommunikation.Core;
using Publico_Kommunikation.Services;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class responsible for managing currently displayed views
    /// within the MainView. Inherits from <see cref="ViewModel"/> and provides functionality
    /// for initializing and switching between views.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        private readonly INavigationService _navigation;
        private ViewModel _quoteViewModel;
        private ViewModel _productsViewModel;
        private ViewModel _quotesViewModel;

        public ViewModel QuoteViewModel
        {
            get => _quoteViewModel;
            private set
            {
                if (_quoteViewModel != value)
                {
                    _quoteViewModel = value;
                    OnPropertyChanged(nameof(QuoteViewModel));
                }
            }
        }

        public ViewModel ProductsViewModel
        {
            get => _productsViewModel;
            set
            {
                if (_productsViewModel != value)
                {
                    _productsViewModel = value;
                    OnPropertyChanged(nameof(ProductsViewModel));
                }
            }
        }

        public ViewModel QuotesViewModel
        {
            get => _quotesViewModel;
            set
            {
                if (_quotesViewModel != value)
                {
                    _quotesViewModel = value;
                    OnPropertyChanged(nameof(QuotesViewModel));
                }
            }
        }

        public RelayCommand ShowQuoteOverviewCommand { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MainViewModel"/>.
        /// Assigns the specified <paramref name="navigation"/>
        /// instance, and configures the <see cref="ShowQuoteOverviewCommand"/> command.
        /// </summary>
        /// <param name="navigation">The <see cref="INavigationService"/> instance used to handle navigation operations.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="navigation"/> is <c>null</c>.</exception>
        public MainViewModel(INavigationService navigation)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));

            ShowQuoteOverviewCommand = new RelayCommand(execute: o => { ShowQuoteOverview(); }, canExecute: o => true);
        }

        /// <summary>
        /// Resets any currently set views after unsubscribing from any associated events.
        /// Initializes and navigates to <see cref="QuoteView"/> and <see cref="ProductsView"/>.
        /// Subscribes the <see cref="QuoteView"/> to the <see cref="QuoteViewModel.OnSwitchRequested"/> event.
        /// </summary>
        private void ShowQuoteAndProducts(Quote quote)
        {
            ResetViews();

            QuoteViewModel = _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteViewModel as QuoteViewModel).OnSwitchRequested += SwitchQuoteViewModel;

            ProductsViewModel = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteViewModel as QuoteViewModel); });
        }

        /// <summary>
        /// Resets any currently set views. Initializes and navigates to <see cref="QuotesViewModel"/>.
        /// </summary>
        private void ShowQuoteOverview()
        {
            ResetViews();
            QuotesViewModel = _navigation.NavigateTo<QuotesViewModel>(vm => { vm.InitializeQuotes(); });
            (QuotesViewModel as QuotesViewModel).OnSwitchRequested += ShowQuoteAndProducts;
        }

        /// <summary>
        /// Switches the current <see cref="QuoteView"/> to the opposite type of <see cref="QuoteViewModel"/>.
        /// Unsubscribes the current <see cref="QuoteViewModel"/> from the <see cref="QuoteViewModel.OnSwitchRequested"/> event
        /// before switching, and subscribes the new <see cref="QuoteViewModel"/> to the <see cref="QuoteViewModel.OnSwitchRequested"/>
        /// event after switching. Reinitializes <see cref="ProductsView"/> with the updated <see cref="QuoteView"/>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> used to initialize the new <see cref="QuoteViewModel"/>.</param>
        private void SwitchQuoteViewModel(Quote quote)
        {
            (QuoteViewModel as QuoteViewModel).OnSwitchRequested -= SwitchQuoteViewModel;

            QuoteViewModel = QuoteViewModel.GetType() == typeof(SumQuoteViewModel)
                ? _navigation.NavigateTo<HourlyRateQuoteViewModel>(vm => { vm.InitializeQuote(quote); })
                : _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteViewModel as QuoteViewModel).OnSwitchRequested += SwitchQuoteViewModel;

            ProductsViewModel = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteViewModel as QuoteViewModel); });
        }

        /// <summary>
        /// Resets any currently set views after unsubscribing from any associated events.
        /// </summary>
        private void ResetViews()
        {
            if (QuoteViewModel is QuoteViewModel quoteViewModel) quoteViewModel.OnSwitchRequested -= SwitchQuoteViewModel;
            if (QuotesViewModel is QuotesViewModel quotesViewModel) quotesViewModel.OnSwitchRequested -= ShowQuoteAndProducts;

            QuoteViewModel = null;
            ProductsViewModel = null;
            QuotesViewModel = null;
        }
    }
}