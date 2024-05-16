using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Frugter.Model;

namespace Frugter.ViewModels
{
    public class ProductRepo
    {
        ProductViewModel pwm = new ProductViewModel();
        
        public List<ProductRepo> productRepo { get; set; }

        public ProductRepo()
        {
            
            productRepo = new List<ProductRepo>
            {
                new ProductRepo{Name = "Apple", Price = 7.95},
                new ProductRepo{Name = "Orange", Price = 5.50},
                new ProductRepo{Name = "Banana", Price = 8.25}

            };


        }

        
    }
}
