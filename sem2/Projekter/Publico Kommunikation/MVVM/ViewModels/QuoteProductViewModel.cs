using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class QuoteProductViewModel : ViewModel
    {
        private ProductRepository _productRepository;
        private QuoteProductRepository _quoteProductRepository;

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
                Model.QuoteProductTimeEstimate = value;
                OnPropertyChanged(nameof(QuoteProductTimeEstimate));
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

        public QuoteProductViewModel(QuoteProduct quoteProduct, ProductRepository productRepository, QuoteProductRepository quoteProductRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _quoteProductRepository = quoteProductRepository ?? throw new ArgumentNullException(nameof(quoteProductRepository));

            Model = quoteProduct ?? throw new ArgumentNullException(nameof(quoteProduct));

            GetProductName();
        }

        public void UpdateQuoteProduct()
        {
            _quoteProductRepository.Update(Model);
        }

        private void GetProductName()
        {
            var product = _productRepository.GetByKey(ProductId);
            ProductName = product.ProductName;
        }
    }
}