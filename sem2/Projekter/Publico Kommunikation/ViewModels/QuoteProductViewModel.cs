using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.Models;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class QuoteProductViewModel : ViewModel
    {

        public QuoteProduct Model;

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
    }
}
