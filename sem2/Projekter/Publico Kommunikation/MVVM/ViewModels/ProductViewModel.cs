using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class ProductViewModel : ViewModel
    {
        private bool _isSelected;
        public Product Model { get; private set; }

        public int ProductId
        {
            get => Model.ProductId;
            private set
            {
                Model.ProductId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        public string ProductName
        {
            get => Model.ProductName;
            private set
            {
                Model.ProductName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public int CategoryId
        {
            get => Model.CategoryId;
            private set
            {
                Model.CategoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

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
            Model = product ?? throw new ArgumentNullException(nameof(product));
        }
    }
}