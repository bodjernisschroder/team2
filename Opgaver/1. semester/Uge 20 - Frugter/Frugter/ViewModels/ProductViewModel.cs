using Frugter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frugter.ViewModels
{
    public class ProductViewModel
    {
        private Product product;
        public string Name 
        {
            get { return product.Name; } 
            set { product.Name = value; } 
        }
        public double Price 
        {
            get { return product.Price; }
            set { product.Price = value; }
        }

        public ProductViewModel(Product product)
        {
            this.product = product;
        }
    }
}


