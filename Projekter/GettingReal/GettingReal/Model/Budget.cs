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

        public List<Product> Products 
        {     
            get { return _products; }
            private set
            {
                if (value != null) _products = value;
                else throw new ArgumentNullException(nameof(Products), "Products list cannot be set to null.");
            }
        }

        public PriceLevel PriceLevel 
        { 
            get { return _priceLevel; }
            set
            {
                if (Enum.IsDefined(typeof(PriceLevel), value)) _priceLevel = value;
                else throw new ArgumentException("Invalid price level value.");
            }
        }

        public double DiscountPercentage 
        { 
            get { return _discountPercentage; }
            set
            {
                if (value >= 0 && value <= 35) _discountPercentage = value;
                else throw new ArgumentOutOfRangeException(nameof(DiscountPercentage), "Discount percentage must be between 0 and 35.");
            }
        }

        public int Sum 
        { 
            get { return _sum; }
            private set
            {
                if (value >= 0) _sum = value;
                else throw new ArgumentOutOfRangeException(nameof(Sum), "Sum must be a non-negative value.");
            }
        }

        public Budget()
        {
            Products = new List<Product>();
            PriceLevel = PriceLevel.High; 
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
