using System;
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

        Product product = new Product("", 0);
        

        public List<Product> Products 
        {     
            get { return _products; }
            set {  _products = value; }
        }

        // Er i tvivl om denne skal med, da den allerede findes i Product.cs - Den er tilføjet her også anyways
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
        }

        public Budget()
        {
            Products = new List<Product>();
            PriceLevel = PriceLevel.High; 
        }
        public Budget(Budget budget, PriceLevel priceLevel)
        {
            PriceLevel = priceLevel; 
            Budget budget1 = budget;
        }


        public void CalculateDiscount (int sum, double discountPercentage)
        {
            double discountAmount = sum * (discountPercentage/100.0); //discountamount er rabatten i kroner og øre 
            double discountedPrice = sum - discountAmount; //discountedPrice er den nye pris efter rabatten

            DiscountPercentage = (sum/discountedPrice)*100.0; //Her beregnes den procentvise rabat - gemt i property DiscountPercentage
        }
        public void CalculateSum(PriceLevel priceLevel, int timeEstimate)
        {
            PriceLevel pricelevel = PriceLevel.High;
            double totalSum = product.CalculatePrice(); 
            
        }


    }
}
