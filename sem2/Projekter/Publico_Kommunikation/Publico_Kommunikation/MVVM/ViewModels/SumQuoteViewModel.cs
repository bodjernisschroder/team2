using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing <see cref="Quote"/> entities.
    /// Inherits from <see cref="QuoteViewModel"/> and extends its functionality
    /// with logic specific to sum-based pricing calculations.
    /// </summary>
    public class SumQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate
        {
            get => Model.HourlyRate;

            set
            {
                Model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
            }
        }

        public override bool HourlyRateIsReadOnly
        {
            get => true;
        }

        public override double Sum
        {
            get => Model.Sum;

            set
            {
                Model.Sum = value;
                OnPropertyChanged(nameof(Sum));
                UpdatePrice();
                UpdateQuote();
            }
        }

        public override bool SumIsReadOnly
        {
            get => false;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SumQuoteViewModel"/>
        /// using the constructor logic from the base class, <see cref="QuoteViewModel"/>.
        /// Sets the <see cref="SwitchText"/> property to "Konvertér Til Fast Timepris."
        /// </summary>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <param name="quoteProductRepository">The repository for managing <see cref="QuoteProduct"/> instances.</param>
        public SumQuoteViewModel(QuoteRepository quoteRepository, ProductRepository productRepository, QuoteProductRepository quoteProductRepository) :
            base(quoteRepository, productRepository, quoteProductRepository)
        {
            SwitchText = "Konvertér Til Fast Timepris";
        }

        /// <summary>
        /// Initializes the specified <paramref name="quote"/> using the implementation in
        /// the base class, <see cref="QuoteViewModel"/>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> to initialize.</param>
        public override void InitializeQuote(Quote quote)
        {
            base.InitializeQuote(quote);
        }

        public override void UpdatePrice()
        {
            var totalEstimatedTime = QuoteProducts.Sum(qp => qp.QuoteProductTimeEstimate);
            Model.HourlyRate = totalEstimatedTime > 0 ? Math.Round(Sum / totalEstimatedTime, 2) : 0;
            QuoteProducts.ToList().ForEach(qp => qp.UpdateQuoteProductPrice(HourlyRate));
            OnPropertyChanged(nameof(HourlyRate));
            OnPropertyChanged(nameof(DiscountedSum));
        }
    }
}