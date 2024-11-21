using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class ProductViewModel : ViewModel
    {
        public Product Model { get; private set; }

        public int ProductId
        {
            get { return Model.ProductId; }
            set
            {
                Model.ProductId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        public string ProductName
        {
            get { return Model.ProductName; }
            set
            {
                Model.ProductName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public int CategoryId
        {
            get { return Model.CategoryId; }
            set
            {
                Model.CategoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public ProductViewModel(Product product)
        {
            Model = product;
        }
    }
}