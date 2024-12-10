using System.Windows;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
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
                if (value < 0)
                {
                    MessageBox.Show("Timepris kan ikke være negativ", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
                UpdatePrice();
                UpdateQuote();
            }
        }

        public override bool HourlyRateIsReadOnly
        {
            get => false;
        }

        public override double Sum
        {
            get => Model.Sum;
            set
            {
                Model.Sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        public override bool SumIsReadOnly
        {
            get => true;
        }

        public override string SwitchText
        {
            get => "Konvertér Til Fast Totalpris";
        }

        ///// <summary>
        /// Initializes a new instance of <see cref="HourlyRateQuoteViewModel"/>
        /// using the constructor logic from the base class, <see cref="QuoteViewModel"/>.
        /// </summary>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <param name="quoteProductRepository">The repository for managing <see cref="QuoteProduct"/> instances.</param>
        public HourlyRateQuoteViewModel(IQuoteRepository quoteRepository, ISimpleKeyRepository<Product> productRepository, ICompositeKeyRepository<QuoteProduct> quoteProductRepository) :
            base(quoteRepository, productRepository, quoteProductRepository) { }

        /// <summary>
        /// Updates the price of the current <see cref="Quote"/>. <see cref="Sum"/> is calculated based
        /// on the total of all <see cref="QuoteProduct.QuoteProductTimeEstimate"/> in the <see cref="Quote"/>
        /// and the manually set <see cref="HourlyRate"/>.
        /// </summary>
        public override void UpdatePrice()
        {
            var totalEstimatedTime = QuoteProducts.Sum(qp => qp.QuoteProductTimeEstimate);
            Model.Sum = totalEstimatedTime > 0 ? Math.Round(totalEstimatedTime * HourlyRate, 2) : 0;
            QuoteProducts.ToList().ForEach(qp => qp.UpdateQuoteProductPrice(HourlyRate));
            OnPropertyChanged(nameof(Sum));
            OnPropertyChanged(nameof(DiscountedSum));
        }
    }
}