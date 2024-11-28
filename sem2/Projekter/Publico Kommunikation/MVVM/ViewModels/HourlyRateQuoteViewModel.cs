using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using Publico_Kommunikation_Project.Services;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class HourlyRateQuoteViewModel : QuoteViewModel
    {
        // public override bool IsActive
        // {
        //     get => _isActive;
        //     set
        //     {
        //         _isActive = value;
        //         OnPropertyChanged(nameof(IsActive));
        //         // Switch();
        //         RaiseSwitchRequested();
        //     }
        // }

        public override double HourlyRate
        {
            get { return _model.HourlyRate; }

            set
            {
                _model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
                UpdateQuote();
            }
        }

        public override double Sum
        {
            get { return _model.Sum; }

            set
            {
                _model.Sum = value;
                OnPropertyChanged(nameof(Sum));
                UpdateQuote();
            }
        }

        // private string _currentViewModel;

        // public string CurrentViewModel
        // {
        //     get { return _currentViewModel; }
        //     set 
        //     { 
        //         _currentViewModel = value;
        //         OnPropertyChanged(nameof(CurrentViewModel));
        //     }
        // }


        // public override void Switch()
        // {
        //     // _mainViewModel.SwitchToSum();
        //     RaiseSwitchRequested();
        // }

        //     if (IsActive)
        //     {
        //         Trace.WriteLine("Trying to switch from Hourly Rate to Sum. Hourly Rate is " + IsActive);
        //         _mainViewModel.Switch();
        //     }

        //     //     Trace.WriteLine("Switching from Hourly Rate to Sum. Hourly Rate is " + IsActive);
        //     //     // SumQuoteViewModel sumQuoteViewModel = (SumQuoteViewModel)_navigation.NavigateTo<SumQuoteViewModel>();
        //     //     // SumQuoteViewModel sumQuoteViewModel = new SumQuoteViewModel();
        //     //     // _mainViewModel.Switch(_sumQuoteViewModel);
        //     // }
        //     // if (IsActive)
        //     // {
        //     //     Trace.WriteLine("Switching to HourlyRate. HourlyRate is " + IsActive);
        //     //     // HourlyRateQuoteViewModel HourlyRateQuoteViewModel = (HourlyRateQuoteViewModel)_navigation.NavigateTo<HourlyRateQuoteViewModel>();
        //     //     // HourlyRateQuoteViewModel hourlyRateQuoteViewModel = new HourlyRateQuoteViewModel();
        //     //     // _mainViewModel.Switch(_hourlyRateQuoteViewModel);
        //     // }
        // }

        public HourlyRateQuoteViewModel(INavigationService navigation, QuoteRepository quoteRepository, QuoteProductRepository quoteProductRepository, ProductRepository productRepository) : base(navigation, quoteRepository, quoteProductRepository, productRepository)
        {
            Trace.WriteLine("HourlyRate summoned");
        }

       
    }
}