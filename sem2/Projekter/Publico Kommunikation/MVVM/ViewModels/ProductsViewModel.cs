using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using System.Collections.ObjectModel;
using Publico_Kommunikation_Project.MVVM.Models;
using Publico_Kommunikation_Project.MVVM.ViewModels;
using System.Windows.Controls;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class ProductsViewModel : ViewModel
    {
        private QuoteViewModel _quoteViewModel;

        // Repository objects serve as a data access object, but do not need to
        // contain objects for themselves.
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<ProductViewModel> Products { get; set; }

        public RelayCommand AddProductsCommand { get; set; }

        public ProductsViewModel(CategoryRepository categoryRepository, ProductRepository productRepository, QuoteViewModel quoteViewModel)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;

            if (quoteViewModel == null) throw new ArgumentNullException(nameof(quoteViewModel));
            _quoteViewModel = quoteViewModel;

            // Populate Categories
            var categories = _categoryRepository.GetAll();
            Categories = new ObservableCollection<Category>(categories);

            // Populate Products
            var products = _productRepository.GetAll();
            Products = new ObservableCollection<ProductViewModel>();

            foreach (Product p in products)
            {
                var productViewModel = new ProductViewModel(p);
                Products.Add(productViewModel); // Spørg i LektieCafé om, hvordan man gør med Views
                                                // Skal Products populates? Hvordan kører man Views og SP fra databasen ind i ViewModel og View?
            }

            AddProductsCommand = new RelayCommand(execute: o => { AddProducts(); }, canExecute: o => true);
        }

        public void AddProducts()
        {
            foreach (ProductViewModel p in Products)
            {
                if (p.IsSelected)
                {
                    var quoteProduct = new QuoteProduct{QuoteId = _quoteViewModel.QuoteId, ProductId = p.ProductId};
                    _quoteViewModel.AddQuoteProduct(quoteProduct);
                }
            }
        }
    }
}