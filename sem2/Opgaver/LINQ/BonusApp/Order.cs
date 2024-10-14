using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        //public delegate double Bonus20(double percentage);
        //Func<double, double> bonusCalc = x => x * 0.2; 

        //bonusCalc(100)
        //20
        
        public BonusProvider Bonus { get; set; }
        private List<Product> _products = new List<Product>();

        //List<Product> result = order.SortProductOrderBy(x => x.Name);
        //List<Product> result = order.SortProductOrderBy(x => x.Value);
        //List<Product> result = order.SortProductOrderBy(x => x.AvailableFrom);
        //List<Product> result = order.SortProductOrderBy(x => x.AvailableTo);

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }


        // Øvelse 2
        public double GetValueOfProducts()
        {
            double value = 0;
            value = _products.Sum(p => p.Value);
            return value;
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        // Øvelse 6
        public double GetBonus(DateTime date, Func<double, double> bonusC)
        {
            return bonusC(GetValueOfProducts(date));
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }

        // Øvelse 6
        public double GetTotalPrice(DateTime date, Func<double, double> bonusC)
        {
            return GetValueOfProducts(date) - GetBonus(date, bonusC);
        }


        // Øvelse 3 
        //public double GetValueOfProducts(DateTime date)
        //{
        //    var filteredProducts = _products.Where(p => p.AvailableFrom <= date && p.AvailableTo >= date);
        //    return filteredProducts.Sum(p => p.Value);
        //}

        // Øvelse 5
        public double GetValueOfProducts(DateTime date)
        {
            var filteredSum = _products.Sum(p => p.AvailableFrom <= date && p.AvailableTo >= date ? p.Value : 0.00); // condition ? 'True' : 'False' 
            return filteredSum;
        }

        // Øvelse 4
        public List<Product> SortProductOrderByAvailableTo()
        {
            var sortedProducts = _products.OrderBy(p => p.AvailableTo).ToList();
            return sortedProducts;
        }

        // Øvelse 7
        public List<Product> SortProductOrderBy(Func<Product, object> keySelector)
        {
            var sortedProducts = _products.OrderBy(keySelector).ToList();
            return sortedProducts;
        }
    }
}