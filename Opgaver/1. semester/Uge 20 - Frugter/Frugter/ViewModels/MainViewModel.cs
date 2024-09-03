using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frugter.ViewModels
{
    public class MainViewModel
    {
        private ProductViewModel _productViewModel;
        public ObservableCollection<ProductViewModel> ProductsVM { get; set;}

       
    }
}
