using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class HourlyRateQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate
        {
            get => Model.HourlyRate;
            set
            {
                Model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
                UpdateQuote();
            }
        }

        public override double Sum
        {
            get => Model.Sum;
            set
            {
                Model.Sum = value;
                OnPropertyChanged(nameof(Sum));
                UpdateQuote();
            }
        }

        public HourlyRateQuoteViewModel(INavigationService navigation, QuoteRepository quoteRepository, QuoteProductRepository quoteProductRepository, ProductRepository productRepository) : base(navigation, quoteRepository, quoteProductRepository, productRepository)
        {
            SwitchText = "Konvertér Til Fast Totalpris";
        }

        public override void InitializeQuote(Quote quote)
        {
            base.InitializeQuote(quote);

            // Disse sættes kun for at kunne se forskel på, hvilken model er synlig. Slet, når Sum og HourlyRate properties er sat korrekt op.
            HourlyRate = 500.0;
            Sum = 5000.0;
        }
    }
}