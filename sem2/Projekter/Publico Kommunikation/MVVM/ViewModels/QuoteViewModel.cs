using System.Collections.ObjectModel;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using System.ComponentModel;
using System.Collections;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing <see cref="Quote"/> entities.
    /// Inherits from <see cref="ViewModel"/> and provides functionality for managing
    /// <see cref="Quote"/> properties and associated <see cref="QuoteProduct"/> entities.
    /// </summary>
    public class QuoteViewModel : ViewModel
    {
        private readonly QuoteRepository _quoteRepository;
        private readonly ProductRepository _productRepository;
        private readonly QuoteProductRepository _quoteProductRepository;
        private string _switchText;
        protected double _discountedSum = 0;

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
                CalcPrice();
            }
        }

        public virtual double Sum {  get; set; }
        public virtual double DiscountedSum { get; set; }

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

        public event Action<Quote> OnSwitchRequested;
        public RelayCommand SwitchCommand { get; set; }
        public RelayCommand DeleteQuoteProductCommand { get; set; }
        public ObservableCollection<QuoteProductViewModel> QuoteProducts { get; set; }

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
        public QuoteViewModel(QuoteRepository quoteRepository, ProductRepository productRepository, QuoteProductRepository quoteProductRepository)
        {
            // Assign Repositories
            _quoteRepository = quoteRepository ?? throw new ArgumentNullException(nameof(quoteRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _quoteProductRepository = quoteProductRepository ?? throw new ArgumentNullException(nameof(quoteProductRepository));

            // Initialize QuoteProducts
            QuoteProducts = new ObservableCollection<QuoteProductViewModel>();

            // Configure Commands
            DeleteQuoteProductCommand = new RelayCommand(execute: o => { DeleteQuoteProduct(o); }, canExecute: o => true);
            SwitchCommand = new RelayCommand(execute: o => { Switch(); }, canExecute: o => true);

            
            QuoteProducts.CollectionChanged += (sender, e) =>
            {
                HandleCollectionChanged(e.NewItems, CalcPrice);
                HandleCollectionChanged(e.OldItems, null);
            };
        }

        /// <summary>
        /// Assigns the specified <paramref name="quote"/> to <see cref="Model"/> and retrieves
        /// any associated quoteProducts using the <see cref="GetAllQuoteProducts"/> method.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> to initialize.</param>
        public virtual void InitializeQuote(Quote quote)
        {
            Model = quote;
            GetAllQuoteProducts();
        }

        /// <summary>
        /// Clears the <see cref="QuoteProducts"/> collection and repopulates it with <see cref="QuoteProductViewModel"/>
        /// instances associated with the current <see cref="Model"/>.
        /// </summary>
        public void GetAllQuoteProducts()
        {
            QuoteProducts.Clear();
            foreach (QuoteProduct quoteProduct in _quoteProductRepository.GetByKeyOne(QuoteId))
            {
                var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, _productRepository, _quoteProductRepository);
                QuoteProducts.Add(quoteProductViewModel);
            }
        }

        /// <summary>
        /// Updates the current <see cref="Model"/> in the <see cref="QuoteRepository"/>.
        /// </summary>
        public void UpdateQuote()
        {
            _quoteRepository.Update(Model);
        }

        /// <summary>
        /// Invokes the <see cref="OnSwitchRequested"/> event for all subscribers,
        /// passing the current <see cref="Model"/> as a parameter.
        /// </summary>
        public void Switch()
        {
            OnSwitchRequested?.Invoke(Model);
        }

        /// <summary>
        /// Creates a new <see cref="QuoteProduct"/> and its corresponding <see cref="QuoteProductViewModel"/>,
        /// associating them with the specified <paramref name="product"/> and the current <see cref="Model"/>.
        /// Adds the <see cref="QuoteProduct"/> to the <see cref="QuoteProductRepository"/> and the
        /// <see cref="QuoteProductViewModel"/> to the <see cref="QuoteProducts"/> collection.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to associate with the new <see cref="QuoteProduct"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="product"/> is <c>null</c>.</exception>
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

        /// <summary>
        /// Deletes the specified <see cref="QuoteProductViewModel"/> from the 
        /// <see cref="QuoteProductRepository"/> and the <see cref="QuoteProducts"/> collection.
        /// </summary>
        /// <param name="o">The <see cref="QuoteProductViewModel"/> to delete.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="o"/> is not an
        /// instance of <see cref="QuoteProductViewModel"/>.</exception>
        public void DeleteQuoteProduct(object o)
        {
            if (o is not QuoteProductViewModel quoteProductViewModel)
                throw new ArgumentException(
                    $"Expected an instance of '{nameof(QuoteProductViewModel)}' but got an instance of '{o?.GetType().Name ?? "null"}'.",
                    nameof(o));

            _quoteProductRepository.Delete(quoteProductViewModel.QuoteId, quoteProductViewModel.ProductId);
            QuoteProducts.Remove(quoteProductViewModel);
            CalcPrice();
        }

        
        private void HandleCollectionChanged(IEnumerable? items, Action? action)
        {
            if (items == null) return;

            foreach (var item in items.OfType<QuoteProductViewModel>())
            {
                item.OnTimeEstimateChanged = action;
            }
        }

        public virtual void CalcPrice()
        {
        }


    }
}