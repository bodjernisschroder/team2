using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;
using Publico_Kommunikation_Project.Services;
using System.Collections.ObjectModel;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
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
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToProductsViewCommand { get; set; }
        // public ObservableCollection<ProductViewModel> SelectedProduct {get ; set; } // Får besked fra ProductsViewModel Add-knap
        private QuoteProductRepository _quoteProductRepository;
        private QuoteRepository _quoteRepository;
        public ObservableCollection<QuoteProductViewModel> QuoteProducts { get; set; }
        public RelayCommand DeleteQuoteProductCommand { get; set; }
        public RelayCommand SaveQuoteAndQuoteProductsCommand { get; set; }

        public QuoteViewModel(INavigationService navigation, QuoteRepository quoteRepository, QuoteProductRepository quoteProductRepository)
        {
            Navigation = navigation;
            NavigateToProductsViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ProductsViewModel>(); }, canExecute: o => true);
            _quoteRepository = quoteRepository;
            _quoteProductRepository = quoteProductRepository;
            SaveQuoteAndQuoteProductsCommand = new RelayCommand(execute: o => { SaveQuoteAndQuoteProducts(); }, canExecute: o => true);
            DeleteQuoteProductCommand = new RelayCommand(execute: o => { DeleteQuoteProduct(o); }, canExecute: o => true);
            QuoteProducts = new ObservableCollection<QuoteProductViewModel>();
        }

        public void Initialize(Quote quote)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));
            _model = quote;

            //// Midlertidige QuoteProducts - manuel indsættelse
            //var quoteProduct = new QuoteProduct { ProductId = 1, QuoteId = 1, QuoteProductPrice = 100.00, QuoteProductTimeEstimate = 1};
            //var quoteProduct1 = new QuoteProduct { ProductId = 2, QuoteId = 1};
            //var quoteProductViewModel = new QuoteProductViewModel(quoteProduct);
            //var quoteProductViewModel1 = new QuoteProductViewModel(quoteProduct1);
            //_quoteProductRepository.Add(quoteProductViewModel.Model);
            //_quoteProductRepository.Add(quoteProductViewModel1.Model);
            //QuoteProducts.Add(quoteProductViewModel);
            //QuoteProducts.Add(quoteProductViewModel1);
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
        public void AddQuoteProduct(QuoteProductViewModel quoteProductViewModel)
        {
            _quoteProductRepository.Add(quoteProductViewModel.Model);
            QuoteProducts.Add(quoteProductViewModel);
        }


        // Deletes QuoteProduct
        public void DeleteQuoteProduct(object o)
        {
            if (o is QuoteProductViewModel quoteProductViewModel)
            {
                _quoteProductRepository.Delete(quoteProductViewModel.QuoteId, quoteProductViewModel.ProductId);
                QuoteProducts.Remove(quoteProductViewModel);
            }
        }

        //Updates Repository
        //Update Quote
        public void SaveQuoteAndQuoteProducts()
        {
            //Error handling her
            foreach (QuoteProductViewModel quoteProductViewModel in QuoteProducts)
            {
                _quoteProductRepository.Update(quoteProductViewModel.Model);
            }

            _quoteRepository.Update(_model);
        }
    }
}
