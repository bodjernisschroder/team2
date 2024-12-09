using System.Windows;
using System.Collections.ObjectModel;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing a collection of <see cref="Quote"/> entities.
    /// Inherits from <see cref="ViewModel"/> and provides functionality to create, load,
    /// and search through <see cref="Quote"/> instances.
    /// </summary>
    public class QuotesViewModel : ViewModel
    {
        private readonly IQuoteRepository _quoteRepository;
        private string _searchQuery;

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    PerformSearch();
                }
            }
        }

        public ObservableCollection<Quote> Quotes { get; set; }

        public RelayCommand CreateQuoteCommand { get; }
        public RelayCommand LoadQuoteCommand { get; }
        public RelayCommand ClearSearchCommand { get; }

        public event Action<Quote> OnSwitchRequested;

        /// <summary>
        /// Initializes a new instance of <see cref="QuoteViewModel"/>.
        /// Assigns the specified repositories, initializes the <see cref="QuoteProducts"/>
        /// collection, and configures the <see cref="DeleteQuoteProductCommand"/> and
        /// <see cref="SwitchCommand"/> commands. 
        /// </summary>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <param name="quoteProductRepository">The repository for managing <see cref="QuoteProduct"/> instances.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the specified repositories are <c>null</c>.</exception>


        /// <summary>
        /// Initializes a new instance of <see cref="QuotesViewModel"/>.
        /// Assigns the specified <paramref name="quoteRepository"/> to <see cref="_quoteRepository"/>,
        /// configures the <see cref="CreateQuoteCommand"/>, <see cref="LoadQuoteCommand"/>, and
        /// <see cref="ClearSearchCommand"/> commands, and calls the <see cref="InitializeQuotes"/> method.
        /// </summary>
        /// <param name="quoteRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QuotesViewModel(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

            CreateQuoteCommand = new RelayCommand(execute: o => { CreateQuote(); }, canExecute: o => true);
            LoadQuoteCommand = new RelayCommand(execute: o => { LoadQuote(o); }, canExecute: o => true);
            ClearSearchCommand = new RelayCommand(execute: o => { ClearSearch(); }, canExecute: o => true);

            InitializeQuotes();
        }

        /// <summary>
        /// Clears the <see cref="Quotes"/> collection for any existing <see cref="Quote"/> entities,
        /// or creates a new <see cref="ObservableCollection{T}"/> if <see cref="Quotes"/> has not yet
        /// been initialized. Populates the <see cref="Quotes"/> collection with all found <see cref="Quote"/>
        /// entities from <see cref="_quoteRepository"/> using the <see cref="IQuoteRepository.GetAll"/> method.
        /// </summary>
        public void InitializeQuotes()
        {
            if (Quotes != null) Quotes.Clear();
            else Quotes = new ObservableCollection<Quote>();

            var quotes = _quoteRepository.GetAll();
            foreach (Quote quote in quotes)
            {
                Quotes.Add(quote);
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="Quote"/>, adds it to the <see cref="_quoteRepository"/>,
        /// and invokes the <see cref="OnSwitchRequested"/> event for all subscribers, passing
        /// the newly created <see cref="quote"/> instance as a parameter
        /// </summary>
        public void CreateQuote()
        {
            var quote = new Quote();
            _quoteRepository.Add(quote);
            OnSwitchRequested?.Invoke(quote);
        }

        /// <summary>
        /// Invokes the <see cref="OnSwitchRequested"/> event for all subscribers, passing
        /// the <see cref="Quote"/> instance provided as the <c>"CommandParameter"</c>> <paramref name="o"/>
        /// from the <see cref="LoadQuotesCommand"/>. If <see cref="o"/> is not a <see cref="Quote"/>,
        /// throws an <see cref="ArgumentException"/> and displays a <see cref="MessageBox"/> to notify
        /// the user of the error.
        /// </summary>
        /// <param name="o">The <see cref="Quote"/> to load.</param>
        public void LoadQuote(object o)
        {
            try
            {
                if (o is not Quote quote)
                    throw new ArgumentException(
                        $"Expected an instance of '{nameof(Quote)}' but got an instance of '{o?.GetType().Name ?? "null"}'.",
                        nameof(o));
                OnSwitchRequested?.Invoke(quote);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Vælg et tilbud fra listen før indlæsning. Eller vælg 'Nyt Tilbud' for at oprette et nyt tilbud",
                    "Fejl ved indlæsning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        /// <summary>
        /// Clears the <see cref="Quotes"/> collection, then populates the collection
        /// with <see cref="Quote"/> entities matching the <see cref="SearchQuery"/>.
        /// If the <see cref="SearchQuery"/> is an empty string, calls the <see cref="ClearSearch"/>
        /// method to populate the <see cref="Quotes"/> collection with all existing <see cref="Quote"/> entities.
        /// </summary>
        public void PerformSearch()
        {
            if (SearchQuery == "")
            {
                ClearSearch();
                return;
            }
            Quotes.Clear();
            var quotes = _quoteRepository.GetBySearchQuery(SearchQuery);
            quotes.ToList().ForEach(Quotes.Add);
        }

        /// <summary>
        /// Sets <see cref="SearchQuery"/> to an empty <see cref="string"/> and calls the
        /// <see cref="InitializeQuotes"/> method to populate the <see cref="Quotes"/> collection
        /// with all existing <see cref="Quote"/> entities.
        /// </summary>
        public void ClearSearch()
        {
            SearchQuery = "";
            InitializeQuotes();
        }
    }
}