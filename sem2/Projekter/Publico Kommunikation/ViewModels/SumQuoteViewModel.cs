using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publico_Kommunikation_Project.Models;
using Publico_Kommunikation_Project.Utilities;
using Publico_Kommunikation_Project.DataAccess;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class SumQuoteViewModel : QuoteViewModel
    {
        public override double HourlyRate { get; set; }

        public override double Sum { get; set; }

        public void Switch()
        {
            throw new NotImplementedException();
        }

        public SumQuoteViewModel(Quote quote) : base(quote)
        {

        }
    }
} 