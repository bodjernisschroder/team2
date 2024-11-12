using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.Models;
using Publico_Kommunikation_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation_Project.ViewModels
{
    public class QuoteViewModel : BaseViewModel
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


        public QuoteViewModel(Quote quote)
        {
            _model = quote;
        }

        public ObservableCollection<ProductViewModel> SelectedProducts;
        private QuoteProductRepository _quoteProductRepository;
        public ObservableCollection<QuoteProduct> QuoteProducts;
        public RelayCommand<int> GetByIdClassTemplateCommand { get; }
        public RelayCommand<ProductViewModel> AddProductsCommand { get; }
        public RelayCommand<QuoteProduct> DeleteQuoteProductCommand { get; }



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
