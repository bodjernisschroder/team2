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

        /// <summary>
        /// Initializes a new instance of <see cref="MainViewModel"/>.
        /// Assigns the specified <paramref name="navigation"/> and <paramref name="quoteRepository"/>
        /// instances, and configures the <see cref="ShowQuoteAndProductsCommand"/> command.
        /// </summary>
        /// <param name="navigation">The <see cref="INavigationService"/> instance used to handle navigation operations.</param>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="navigation"/> or <paramref name="quoteRepository"/> is <c>null</c>.</exception>
        public MainViewModel(INavigationService navigation, QuoteRepository quoteRepository)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

            ShowQuoteAndProductsCommand = new RelayCommand(execute: o => { ShowQuoteAndProducts(); }, canExecute: o => true);
        }

        /// <summary>
        /// Initializes and navigates to <see cref="QuoteView"/> and <see cref="ProductsView"/>.
        /// Subscribes the <see cref="QuoteView"/> to the <see cref="QuoteViewModel.OnSwitchRequested"/> event.
        /// </summary>
        private void ShowQuoteAndProducts()
        {
            // Dette skal laves om senere - så den får en quote fra en anden klasse, højst sandsynligt,
            // da det kan være QuoteView enten skal vises med en ny eller eksisterende Quote.
            var quote = new Quote();
            _quoteRepository.Add(quote);

            // Navigates to and initializes SumQuoteViewModel with the instance of quote.
            QuoteView = _navigation.NavigateTo<SumQuoteViewModel>(vm => { vm.InitializeQuote(quote); });
            (QuoteView as QuoteViewModel).OnSwitchRequested += Switch;

            // Navigates to and initializes ProductsViewModel with the instance of quote.
            ProductsView = _navigation.NavigateTo<ProductsViewModel>(vm => { vm.InitializeQuoteViewModel(QuoteView as QuoteViewModel); });
        }

        /// <summary>
        /// Switches the current <see cref="QuoteView"/> to the opposite type of <see cref="QuoteViewModel"/>.
        /// Unsubscribes the current <see cref="QuoteViewModel"/> from the <see cref="QuoteViewModel.OnSwitchRequested"/> event
        /// before switching, and subscribes the new <see cref="QuoteViewModel"/> to the <see cref="QuoteViewModel.OnSwitchRequested"/>
        /// event after switching. Reinitializes <see cref="ProductsView"/> with the updated <see cref="QuoteView"/>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> used to initialize the new <see cref="QuoteViewModel"/>.</param>
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