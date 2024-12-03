using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class QuotesViewModel : ViewModel
    {
        private readonly QuoteRepository _quoteRepository;
        private readonly QuoteViewModel _quoteViewModel;

        protected Quote Model { get; private set; }

        public ObservableCollection<Quote> Quotes { get; set; }
        public RelayCommand CreateQuoteCommand { get; }
        public RelayCommand LoadQuoteCommand { get; }
        public event Action<Quote> OnSwitchRequested;

        public QuotesViewModel(QuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));
            Quotes = new ObservableCollection<Quote>();
            CreateQuoteCommand = new RelayCommand(execute: o => { CreateQuote(); }, canExecute: o => true);
            LoadQuoteCommand = new RelayCommand(execute: o => { LoadQuote(o); }, canExecute: o => true);

            InitializeQuotes();
        }

        public void InitializeQuotes()
        {
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
            if (o is not Quote quote)
            {
                throw new ArgumentException(
                    $"Expected an instance of '{nameof(Quote)}' but got an instance of '{o?.GetType().Name ?? "null"}'.",
                    nameof(o));
            }

            OnSwitchRequested?.Invoke(quote);
        }

    }
}