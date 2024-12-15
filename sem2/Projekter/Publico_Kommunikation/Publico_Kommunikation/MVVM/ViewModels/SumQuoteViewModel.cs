using System.Windows;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing <see cref="Quote"/> entities.
    /// Inherits from <see cref="QuoteViewModel"/> and extends its functionality
    /// with logic specific to sum-based pricing calculations.
    /// </summary>
    public class SumQuoteViewModel : QuoteViewModel
    {
        public override double? HourlyRate
        {
            get => Model.HourlyRate;

            set
            {
                if (Model.HourlyRate != value)
                {
                    Model.HourlyRate = value;
                    OnPropertyChanged(nameof(HourlyRate));
                }
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
                if (value < 0)
                {
                    MessageBox.Show("Totalpris kan ikke være negativ", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (Model.Sum != value)
                {
                    Model.Sum = value;
                    OnPropertyChanged(nameof(Sum));
                    UpdatePrice();
                }
            }
        }

        public override bool SumIsReadOnly
        {
            get => false;
        }

        public override string SwitchText
        {
            get => "Konvertér Til Fast Timepris";
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SumQuoteViewModel"/>
        /// using the constructor logic from the base class, <see cref="QuoteViewModel"/>.
        /// </summary>
        /// <param name="quoteRepository">The repository for managing <see cref="Quote"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <param name="quoteProductRepository">The repository for managing <see cref="QuoteProduct"/> instances.</param>
        public SumQuoteViewModel(IQuoteRepository quoteRepository, ISimpleKeyRepository<Product> productRepository, ICompositeKeyRepository<QuoteProduct> quoteProductRepository) :
            base(quoteRepository, productRepository, quoteProductRepository) { }

        /// <summary>
        /// Updates the price of the current <see cref="Quote"/>. <see cref="HourlyRate"/> is calculated based
        /// on the total of all <see cref="QuoteProduct.QuoteProductTimeEstimate"/> in the <see cref="Quote"/>
        /// and the manually set <see cref="Sum"/>.
        /// </summary>
        public override void UpdatePrice()
        {
            var totalEstimatedTime = QuoteProducts.Sum(qp => qp.QuoteProductTimeEstimate);
            Model.HourlyRate = totalEstimatedTime > 0 ? Math.Round((Sum / (totalEstimatedTime ?? 1)), 2) : 0;
            QuoteProducts.ToList().ForEach(qp => qp.UpdateQuoteProductPrice(HourlyRate ?? 0));
            OnPropertyChanged(nameof(HourlyRate));
            OnPropertyChanged(nameof(DiscountedSum));
            UpdateQuote();
        }
    }
}