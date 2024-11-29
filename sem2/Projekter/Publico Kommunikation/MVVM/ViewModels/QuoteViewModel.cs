using System.Collections.ObjectModel;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class QuoteViewModel : ViewModel
    {
        private readonly QuoteRepository _quoteRepository;
        private readonly ProductRepository _productRepository;
        private readonly QuoteProductRepository _quoteProductRepository;
        private string _switchText;

        protected Quote Model { get; private set; }

        public int QuoteId
        {
            get { return Model.QuoteId; }
            set
            {
                Model.QuoteId = value;
                OnPropertyChanged(nameof(QuoteId));
            }
        }

        public virtual double HourlyRate { get; set; }

        public decimal DiscountPercentage
        {
            get { return Model.DiscountPercentage; }
            set
            {
                Model.DiscountPercentage = value;
                OnPropertyChanged(nameof(DiscountPercentage));
            }
        }

        public virtual double Sum {  get; set; }

        public string SwitchText
        {
            get => _switchText;
            set
            {
                if (_switchText  == value) return;
                _switchText = value;
                OnPropertyChanged(nameof(SwitchText));
            }
        }
        public Action<Quote> OnSwitchRequested;
        public RelayCommand SwitchCommand { get; set; }
        public RelayCommand DeleteQuoteProductCommand { get; set; }
        public ObservableCollection<QuoteProductViewModel> QuoteProducts { get; set; }

        public QuoteViewModel(INavigationService navigation, QuoteRepository quoteRepository, QuoteProductRepository quoteProductRepository, ProductRepository productRepository)
        {
            // Initialize Repositories
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _quoteProductRepository = quoteProductRepository ?? throw new ArgumentNullException(nameof(quoteProductRepository));

            // Initialize QuoteProducts
            QuoteProducts = new ObservableCollection<QuoteProductViewModel>();

            // Initialize Commands
            DeleteQuoteProductCommand = new RelayCommand(execute: o => { DeleteQuoteProduct(o); }, canExecute: o => true);
            SwitchCommand = new RelayCommand(execute: o => { Switch(); }, canExecute: o => true);
        }
                    
        public virtual void InitializeQuote(Quote quote)
        {
            Model = quote;
            GetAllQuoteProducts();
        }

        public void GetAllQuoteProducts()
        {
            QuoteProducts.Clear();
            foreach (QuoteProduct quoteProduct in _quoteProductRepository.GetByFirstKey(QuoteId))
            {
                var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, _productRepository, _quoteProductRepository);
                QuoteProducts.Add(quoteProductViewModel);
            }
        }

        public void UpdateQuote()
        {
            _quoteRepository.Update(Model);
        }

        public void Switch()
        {
            OnSwitchRequested?.Invoke(Model);
        }

        public void AddQuoteProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            // Create QuoteProduct and QuoteProductViewModel
            var quoteProduct = new QuoteProduct { QuoteId = QuoteId, ProductId = product.ProductId };
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, _productRepository, _quoteProductRepository);
            
            // Add QuoteProduct to Repository and QuoteProductViewModel to QuoteProducts
            _quoteProductRepository.Add(quoteProduct);
            QuoteProducts.Add(quoteProductViewModel);
        }


        public void DeleteQuoteProduct(object o)
        {
            if (!(o is QuoteProductViewModel quoteProductViewModel)) return;

            _quoteProductRepository.Delete(quoteProductViewModel.QuoteId, quoteProductViewModel.ProductId);
            QuoteProducts.Remove(quoteProductViewModel);
        }
    }
}