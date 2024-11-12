using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publico_Kommunikation_Project.Models;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class HourlyRateQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate { get; set; }

        public override double Sum { get; set; }

        public void Switch()
        {
            throw new NotImplementedException();
        }
        public HourlyRateQuoteViewModel(Quote quote) : base(quote)
        {

        }
    }
}
