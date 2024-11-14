using Publico_Kommunikation_Project.Models;
using Publico_Kommunikation_Project.ViewModels;

namespace Publico_Kommunikation_Project.Utilities
{
    public class ViewModelFactory 
    {
        // Dictionary that maps each ViewModel type to a function responsible for creating instances of that ViewModel.
        // Key = type of the object that is to be created,
        // Value = delegate that creates the ViewModel using parameters if defined in the constructor of each ViewModel
        private readonly Dictionary<Type, Func<object?, BaseViewModel>> _viewModelCreators = new()
        {
            // typeof = gets the type of the object e.g. SumQuoteViewModel which aligns with the Key in the dictionary
            // param is used to create the ViewModel object
            { typeof(SumQuoteViewModel), quote => new SumQuoteViewModel(quote as Quote) },
            { typeof(HourlyRateQuoteViewModel), quote => new HourlyRateQuoteViewModel(quote as Quote) },
            { typeof(ProductsViewModel), param => new ProductsViewModel() }
        };

        // Takes a Type of ViewModel and returns an instance of that ViewModel
        public TViewModel Create<TViewModel>(object? param) where TViewModel : BaseViewModel
        {
            if (_viewModelCreators.TryGetValue(typeof(TViewModel), out var creator))
                return creator(param) as TViewModel;
            throw new InvalidOperationException($"ViewModel of type {typeof(TViewModel)} does not exist.");
        }
    }
}