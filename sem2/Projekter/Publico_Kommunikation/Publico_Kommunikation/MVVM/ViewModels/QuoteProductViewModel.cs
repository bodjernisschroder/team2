using System.Windows;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for representing and managing <see cref="QuoteProduct"/> entities.
    /// Inherits from <see cref="ViewModel"/> and provides functionality for exposing and updating
    /// <see cref="QuoteProduct"/> properties, and retrieving related <see cref="Product"/> details
    /// from the <see cref="ProductRepository"/>.
    /// </summary>
    public class QuoteProductViewModel : ViewModel
    {
        private ISimpleKeyRepository<Product> _productRepository;
        private ICompositeKeyRepository<QuoteProduct> _quoteProductRepository;

        public Action? OnTimeEstimateChanged { get; set; } 

        private string _productName;
        public QuoteProduct Model { get; private set; }


        public int QuoteId
        {
            get => Model.QuoteId;
            set
            {
                Model.QuoteId = value;
                OnPropertyChanged(nameof(QuoteId));
            }
        }

        public int ProductId
        {
            get => Model.ProductId;
            set
            {
                Model.ProductId = value;
                OnPropertyChanged(nameof(ProductId));
                GetProductName();
            }
        }

        public string ProductName
        {
            get => _productName;
            private set 
            { 
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public double QuoteProductTimeEstimate
        {
            get => Model.QuoteProductTimeEstimate;
            set
            {
                if (value < 0.0)
                {
                    MessageBox.Show("Tidsestimatet kan ikke være negativt", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Model.QuoteProductTimeEstimate = value;
                OnPropertyChanged(nameof(QuoteProductTimeEstimate));
                OnTimeEstimateChanged?.Invoke();
                UpdateQuoteProduct();
            }
        }

        public double QuoteProductPrice
        {
            get => Model.QuoteProductPrice;
            set
            {
                Model.QuoteProductPrice = value;
                OnPropertyChanged(nameof(QuoteProductPrice));
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="QuoteProductViewModel"/>,
        /// associates it with the specified <paramref name="quoteProduct"/>, and calls <see cref="GetProductName"/>.
        /// </summary>
        /// <param name="quoteProduct"></param>
        /// <param name="productRepository"></param>
        /// <param name="quoteProductRepository"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="quoteProduct"/>, <paramref name="productRepository"/>, or
        /// <paramref name="quoteProductRepository"/> is <c>null</c></exception>
        public QuoteProductViewModel(QuoteProduct quoteProduct, ISimpleKeyRepository<Product> productRepository, ICompositeKeyRepository<QuoteProduct> quoteProductRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _quoteProductRepository = quoteProductRepository ?? throw new ArgumentNullException(nameof(quoteProductRepository));

            Model = quoteProduct ?? throw new ArgumentNullException(nameof(quoteProduct));

            GetProductName();
        }

        /// <summary>
        /// Updates the current <see cref="Model"/> in the <see cref="QuoteProductRepository"/>.
        /// </summary>
        public void UpdateQuoteProduct()
        {
                _quoteProductRepository.Update(Model);
        }

        /// <summary>
        /// Updates the <see cref="QuoteProductPrice"/> based on the specified <paramref name="hourlyRate"/>
        /// and the <see cref="QuoteProductTimeEstimate"/>.
        /// </summary>
        /// <param name="hourlyRate">The hourly rate used to calculate the <see cref="QuoteProductPrice"/>.</param>
        public void UpdateQuoteProductPrice(double hourlyRate)
        {
            QuoteProductPrice = Math.Round(QuoteProductTimeEstimate * hourlyRate, 2);
        }

        /// <summary>
        /// Retrieves the <see cref="Product"/> associated with <see cref="ProductId"/> from the
        /// <see cref="ProductRepository"/>, and assigns its <see cref="Product.ProductName"/> to <see cref="ProductName"/>.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Thrown when no <see cref="ProductId"/> matches a <see cref="Product.ProductId"/></exception>
        private void GetProductName()
        {
            var product = _productRepository.GetByKey(ProductId) ??
                throw new KeyNotFoundException($"No ProductId matching '{ProductId}' of QuoteProduct found in {nameof(_productRepository)}.");
            ProductName = product.ProductName;
        }
    }
}