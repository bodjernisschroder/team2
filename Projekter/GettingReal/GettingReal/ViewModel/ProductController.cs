using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal.View;

namespace GettingReal
{
    public class ProductController
    {
        public Product CreateProduct(string name, int timeEstimate, PriceLevel priceLevel)
        {
            Product product = new Product(name, timeEstimate, priceLevel);
            return product;
        }

        public void ChangeTimeEstimate(Product product, int timeEstimate)
        {
            product.TimeEstimate = timeEstimate;
            UpdatePrice(product);
        }

        public void ChangeTimeEstimate(Product product, int timeEstimate, PriceLevel priceLevel)
        {
            product.TimeEstimate = timeEstimate;
            ChangePriceLevel(product, priceLevel);
        }

        public void ChangePriceLevel(Product product, PriceLevel priceLevel)
        {
            product.PriceLevel = priceLevel;
            UpdatePrice(product);
        }

        public void MakeCustomPrice(Product product, int price)
        {
            product.MakeCustomPrice(price);
        }

        public void UpdatePrice(Product product)
        {
            product.CalculatePrice();
        }
    }
}