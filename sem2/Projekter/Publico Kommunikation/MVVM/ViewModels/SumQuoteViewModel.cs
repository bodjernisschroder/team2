using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using Publico_Kommunikation_Project.Services;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class SumQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate { get; set; }

        public override double Sum { get; set; }

        public void Switch()
        {
            throw new NotImplementedException();
        }

        public SumQuoteViewModel(INavigationService navigation, QuoteRepository quoteRepository, QuoteProductRepository quoteProductRepository) : base(navigation, quoteRepository, quoteProductRepository)
        {
        }
    }
}