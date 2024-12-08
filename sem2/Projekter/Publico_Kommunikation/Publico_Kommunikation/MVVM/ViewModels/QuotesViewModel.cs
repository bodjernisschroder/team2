using Publico_Kommunikation.Core;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Publico_Kommunikation.MVVM.ViewModels
{
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

        public QuotesViewModel(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));

            CreateQuoteCommand = new RelayCommand(execute: o => { CreateQuote(); }, canExecute: o => true);
            LoadQuoteCommand = new RelayCommand(execute: o => { LoadQuote(o); }, canExecute: o => true);
            ClearSearchCommand = new RelayCommand(execute: o => { ClearSearch(); }, canExecute: o => true);

            InitializeQuotes();
        }

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

        public void CreateQuote()
        {
            var quote = new Quote();
            _quoteRepository.Add(quote);
            OnSwitchRequested?.Invoke(quote);
        }

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
                MessageBox.Show("Vælg et tilbud fra listen før indlæsning. Eller vælg 'Nyt Tilbud' for at oprette et nyt tilbud", "Fejl ved indlæsning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

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

        public void ClearSearch()
        {
            SearchQuery = "";
            InitializeQuotes();
        }
    }
}