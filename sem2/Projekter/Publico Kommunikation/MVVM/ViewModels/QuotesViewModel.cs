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

        //public RelayCommand LoadQuoteCommand { get; }

        public QuotesViewModel(QuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));
            Quotes = new ObservableCollection<Quote>();
            //LoadQuoteCommand = new RelayCommand(execute: o => { DeleteQuoteProduct(o); }, canExecute: o => true);

            InitializeQuotes();
        }

        public void InitializeQuotes()
        {
            var quotes = _quoteRepository.GetAll();

            Quotes = new ObservableCollection<Quote>();

            foreach (Quote quote in quotes)
            {

                Quotes.Add(quote);
            }
        }

    }
}