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
        private readonly IQuoteRepository _quoteRepository;
        private ViewModel _quoteView;
        private ViewModel _productsView;
        private ViewModel _quotesView;

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

        public ViewModel QuotesView
        {
            get => _quotesView;
            set
            {
                if (_quotesView != value)
                {
                    _quotesView = value;
                    OnPropertyChanged(nameof(QuotesView));
                }
            }
        }
        public RelayCommand ShowQuoteOverviewCommand { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MainViewModel"/>.
        /// Assigns the specified <paramref name="navigation"/> and <paramref name="quoteRepository"/>
        /// instances, and configures the <see cref="ShowQuoteOverviewCommand"/> command.
        /// </summary>
        /// <param name="navigation">The <see cref="INavigationService"/> instance used to handle navigation operations.</param>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="navigation"/> or <paramref name="quoteRepository"/> is <c>null</c>.</exception>
        public MainViewModel(INavigationService navigation, IQuoteRepository quoteRepository)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

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

            QuoteView = _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteView as QuoteViewModel).OnSwitchRequested += SwitchQuoteViewModel;

            ProductsView = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteView as QuoteViewModel); });
        }

        /// <summary>
        /// Resets any currently set views. Initializes and navigates to <see cref="QuotesViewModel"/>.
        /// </summary>
        private void ShowQuoteOverview()
        {
            ResetViews();
            QuotesView = _navigation.NavigateTo<QuotesViewModel>(vm => { vm.InitializeQuotes(); });
            (QuotesView as QuotesViewModel).OnSwitchRequested += ShowQuoteAndProducts;
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
            (QuoteView as QuoteViewModel).OnSwitchRequested -= SwitchQuoteViewModel;

            QuoteView = QuoteView.GetType() == typeof(SumQuoteViewModel)
                ? _navigation.NavigateTo<HourlyRateQuoteViewModel>(vm => { vm.InitializeQuote(quote); })
                : _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteView as QuoteViewModel).OnSwitchRequested += SwitchQuoteViewModel;

            ProductsView = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteView as QuoteViewModel); });
        }

        /// <summary>
        /// Resets any currently set views after unsubscribing from any associated events.
        /// </summary>
        private void ResetViews()
        {
            if (QuoteView is QuoteViewModel quoteViewModel) quoteViewModel.OnSwitchRequested -= SwitchQuoteViewModel;
            if (QuotesView is QuotesViewModel quotesViewModel) quotesViewModel.OnSwitchRequested -= ShowQuoteAndProducts;

            QuoteView = null;
            ProductsView = null;
            QuotesView = null;
        }
    }
}