﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class Budget 
    {
        
        private List<Product> _products;
        private PriceLevel _priceLevel;
        private double _discountPercentage;
        private int _sum;

        //Product product = new Product("", 0);
        

        public List<Product> Products 
        {     
            get { return _products; }
            set {  _products = value; }
        }

        // Er i tvivl om denne skal med, da den allerede findes i Product.cs - Den er tilføjet her også anyways
        // Skal budget have et pricelevel generelt eller skal alle pricelevels for products ændres
        public PriceLevel PriceLevel 
        { 
            get { return _priceLevel; } 
            set { _priceLevel = value; } 
        }

        public double DiscountPercentage 
        { 
            get { return _discountPercentage; } 
            set { _discountPercentage = value; } 
        }

        public int Sum 
        { 
            get { return _sum; }  
            set { _sum = value; }
        }

        public Budget()
        {
            Products = new List<Product>();
            PriceLevel = PriceLevel.High; 
        }
        public Budget(Budget budget, PriceLevel priceLevel)
        {
            Products = new List<Product>();
            PriceLevel = priceLevel; 
            Budget budget1 = budget;
        }



        public void CalculateDiscount (double discountPercentage)
        {
            double discountAmount = Sum * (discountPercentage/100.0); //discountamount er rabatten i kroner og øre 
            double discountedPrice = Sum - discountAmount; //discountedPrice er den nye pris efter rabatten

            DiscountPercentage = (Sum/discountedPrice)*100.0; //Her beregnes den procentvise rabat - gemt i property DiscountPercentage
        }
        public void CalculateSum()
        {

            int sum = 0;
            foreach (Product product in Products)
            {
               sum += product.Price; 
            }

            Sum = sum; 
            
        }

    }
}
