using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class QuoteProductViewModel : ViewModel
    {

        public QuoteProduct Model;
        private string _quoteProductName;
        private QuoteProductRepository _quoteProductRepository;

        public QuoteProductViewModel(QuoteProduct quoteProduct)
        {
            Model = quoteProduct;
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
            }
        }


        //Anna kigger på denne 
        public string QuoteProductName
        {
            get { return _quoteProductName; }
            set 
            { 
                _quoteProductName = value;
                OnPropertyChanged(QuoteProductName);
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
    }
}