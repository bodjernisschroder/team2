using Publico_Kommunikation_Project.Services;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Publico_Kommunikation_Project.Core;
using System.Collections;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing <see cref="Quote"/> entities.
    /// Inherits from <see cref="QuoteViewModel"/> and extends its functionality
    /// with logic specific to hourly rate-based pricing calculations.
    /// </summary>
    public class HourlyRateQuoteViewModel : QuoteViewModel
    {
        public RelayCommand UpdateTotalPriceCommand { get; }

        public override double HourlyRate
        {
            get => Model.HourlyRate;
            set
            {
                Model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
                CalcPrice();
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

        public override double DiscountedSum
        {
            get => _discountedSum;
            set
            {
                _discountedSum = value;
                OnPropertyChanged(nameof(DiscountedSum));
                UpdateQuote();
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="HourlyRateQuoteViewModel"/>
        /// using the constructor logic from the base class, <see cref="QuoteViewModel"/>.
        /// Sets the <see cref="SwitchText"/> property to "Konvertér Til Fast Timepris."
        /// </summary>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <param name="quoteProductRepository">The repository for managing <see cref="QuoteProduct"/> instances.</param>
        public HourlyRateQuoteViewModel(QuoteRepository quoteRepository, ProductRepository productRepository, QuoteProductRepository quoteProductRepository) :
            base(quoteRepository, productRepository, quoteProductRepository)
        {
            SwitchText = "Konvertér Til Fast Totalpris";
        }

        /// <summary>
        /// Initializes the specified <paramref name="quote"/> using the implementation in
        /// the base class, <see cref="QuoteViewModel"/>.
        /// </summary>
        /// <param name="quote">The <see cref="Quote"/> to initialize.</param>
        public override void InitializeQuote(Quote quote)
        {
            base.InitializeQuote(quote);
            CalcPrice();
        }

        

        public override void CalcPrice()
        {
            var totalEstimatedTime = QuoteProducts.Sum(qp => qp.QuoteProductTimeEstimate);
            if (totalEstimatedTime > 0)
            {
                Model.Sum = Math.Round(totalEstimatedTime * HourlyRate, 2);
            }
            else { Sum = 0; }
            OnPropertyChanged(nameof(Sum));

            DiscountedSum = Math.Round(Sum - (Sum * ((double)DiscountPercentage / 100)), 2);
        }
    }
}