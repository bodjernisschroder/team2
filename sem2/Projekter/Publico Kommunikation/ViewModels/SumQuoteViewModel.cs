﻿using System;
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
    public class SumQuoteViewModel : BaseViewModel
    {
        private int _quoteId;
        private double _hourlyRate;
        private double _discountPercentage;
        private double _sum;

        public virtual double HourlyRate 
        {
            get { return _hourlyRate; }

            set
            {
                _hourlyRate = value;
                OnPropertyChanged(nameof(HourlyRate));
            }
        }

        public int QuoteId
        {
            get { return _quoteId; }
            set
            {
                _quoteId = value;
                OnPropertyChanged(nameof(QuoteId));
            }
        }

        public double DiscountPercentage
        {
            get { return _discountPercentage; }
            set
            {
                _discountPercentage = value;
                OnPropertyChanged(nameof(DiscountPercentage));
            }
        }

        public virtual double Sum
        {
            get { return _sum; }

            set
            {
                _sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }

        public ObservableCollection<ProductViewModel> SelectedProducts;
        private QuoteProductRepository _quoteProductRepository;
        public ObservableCollection<QuoteProduct> QuoteProducts;
        public RelayCommand<int> GetByIdClassTemplateCommand { get; }
        public RelayCommand<ProductViewModel> AddProductsCommand { get; }
        public RelayCommand<QuoteProduct> DeleteQuoteProductCommand { get; }


        public SumQuoteViewModel(Quote quote)
        {
            //Load method call
        }

        //Enten at have en GetAll eller en GetById 
        public void GetAllQuoteProducts(int quoteId)
        {
           //Alle dem, som passer med QuoteProducts
           //Indsæt dem, som har den quoteId - som parameter
           //- indsættes i den liste, som hedder QuoteProducts
        }


        // Retrieves ClassTemplate by ID and adds to collection
        public void GetByIdQuoteProduct(int quoteId)
        {
            //Den her instantierer listen med QuoteProducts - vi laver det tirsdag
            //QuoteProducts.
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