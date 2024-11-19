using Publico_Kommunikation_Project.MVVM.Models;
using Publico_Kommunikation_Project.Services;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class HourlyRateQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate { get; set; }

        public override double Sum { get; set; }

        public void Switch()
        {
            throw new NotImplementedException();
        }
        public HourlyRateQuoteViewModel(INavigationService navigation) : base(navigation)
        {

        }
    }
}
