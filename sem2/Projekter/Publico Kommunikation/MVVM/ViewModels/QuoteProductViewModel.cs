using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class QuoteProductViewModel : ViewModel
    {

        public QuoteProduct Model;
        private string _productName;
        private ProductRepository _productRepository;
        private QuoteProductRepository _quoteProductRepository;


        public QuoteProductViewModel(QuoteProduct quoteProduct, ProductRepository productRepository, QuoteProductRepository quoteProductRepository)
        {
            Model = quoteProduct;
            _productRepository = productRepository;
            _quoteProductRepository = quoteProductRepository;
            GetProductName();
        }

        public int QuoteId
        {
            get { return Model.QuoteId; }
            set
            {
                Model.QuoteId = value;
                OnPropertyChanged(nameof(QuoteId));
            }
        }

        public int ProductId
        {
            get { return Model.ProductId; }
            set
            {
                Model.ProductId = value;
                OnPropertyChanged(nameof(ProductId));
                GetProductName();
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set 
            { 
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }


        public double QuoteProductTimeEstimate
        {
            get { return Model.QuoteProductTimeEstimate; }
            set
            {
                Model.QuoteProductTimeEstimate = value;
                OnPropertyChanged(nameof(QuoteProductTimeEstimate));
            }
        }

        public double QuoteProductPrice
        {
            get { return Model.QuoteProductPrice; }
            set
            {
                Model.QuoteProductPrice = value;
                OnPropertyChanged(nameof(QuoteProductPrice));
            }
        }

        public void UpdateQuoteProduct(QuoteProduct quoteProduct)
        {
            _quoteProductRepository.Update(quoteProduct);
        }

        public void GetProductName()
        {
            var product = _productRepository.GetByKey(ProductId);
            ProductName = product.ProductName;
        }
    }
}