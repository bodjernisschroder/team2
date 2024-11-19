using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.Models;
using Publico_Kommunikation_Project.Services;
using System.Collections.ObjectModel;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class QuoteViewModel : ViewModel
    {

        private Quote _model;

        public int QuoteId
        {
            get { return _model.QuoteId; }
            set
            {
               _model.QuoteId = value;
                OnPropertyChanged(nameof(QuoteId));
            }
        }

        public virtual double HourlyRate
        {
            get { return _model.HourlyRate; }

            set
            {
                _model.HourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
            }
        }


        public double DiscountPercentage
        {
            get { return _model.DiscountPercentage; }
            set
            {
                _model.DiscountPercentage = value;
                OnPropertyChanged(nameof(DiscountPercentage));
            }
        }

        public virtual double Sum
        {
            get { return _model.Sum; }

            set
            {
                _model.Sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        public RelayCommand NavigateToProductsViewCommand { get; set; }
        public ObservableCollection<ProductViewModel> SelectedProducts;
        private QuoteProductRepository _quoteProductRepository;
        public ObservableCollection<QuoteProduct> QuoteProducts;
        private Quote quote;

        public RelayCommand GetByIdClassTemplateCommand { get; }
        public RelayCommand AddProductsCommand { get; }
        public RelayCommand DeleteQuoteProductCommand { get; }

        public QuoteViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToProductsViewCommand = new RelayCommand( execute: o => { Navigation.NavigateTo<ProductsViewModel>(); }, canExecute: o => true);
        }

        public QuoteViewModel(Quote quote)
        {
            this.quote = quote;
        }

        public void Initialize(Quote quote)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));
            _model = quote;
        }

        //Enten at have en GetAll eller en GetById 
        public void GetAllQuoteProducts(int quoteId)
        {
            throw new NotImplementedException();
            //Alle dem, som passer med QuoteProducts
            //Indsæt dem, som har den quoteId - som parameter
            //- indsættes i den liste, som hedder QuoteProducts
        }

        // Adds ClassTemplate to collections
        // Går igennem listen med SelectedProducts og opretter og tilføjer dem til QuoteProducts
        public void AddQuoteProduct(QuoteProduct quoteProduct)
        {

        }

        // Updates Repository
        //Update QuoteProduct 
        public void UpdateQuoteProduct(QuoteProduct quoteProduct)
        {

        }

        // Deletes ClassTemplate from collections
        // Deletes QuoteProduct
        public void DeleteQuoteProduct(QuoteProduct quoteProduct)
        {

        }
    }
}
