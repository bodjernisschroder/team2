using System.Collections.ObjectModel;
using Publico_Kommunikation_Project.Core;
using Publico_Kommunikation_Project.DataAccess;
using Publico_Kommunikation_Project.MVVM.Models;

namespace Publico_Kommunikation_Project.MVVM.ViewModels
{
    public class ProductsViewModel : ViewModel
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;

        private QuoteViewModel _quoteViewModel;

        public int SelectedIndex { get; set; }
        public Dictionary<Category, ObservableCollection<ProductViewModel>> CategoryProducts { get; set; }

        public RelayCommand AddProductsToQuoteCommand { get; set; }

        public ProductsViewModel(CategoryRepository categoryRepository, ProductRepository productRepository)
        {
            // Initialize repositories
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            
            // Initialize CategoryProducts
            InitializeCategoryProducts();

            // Initialize AddProductsToQuoteCommand
            AddProductsToQuoteCommand = new RelayCommand(execute: o => { AddProductsToQuote(); }, canExecute: o => true);
        }

        public void InitializeQuoteViewModel(QuoteViewModel quoteViewModel)
        {
            _quoteViewModel = quoteViewModel;
        }

        private void InitializeCategoryProducts()
        {
            // GetAll categories and products
            var categories = _categoryRepository.GetAll();
            var products = _productRepository.GetAll();

            // Populate CategoryProducts
            CategoryProducts = new Dictionary<Category, ObservableCollection<ProductViewModel>>();

            foreach (Product product in products)
            {
                // Creates instance of ProductViewModel
                var productViewModel = new ProductViewModel(product);

                // Finds category with CategoryId matching product.CategoryId. If not found, throws new KeyNotFoundException.
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId) ?? throw new KeyNotFoundException($"CategoryId '{product.CategoryId}' of Product '{product.ProductId}' not found in Category table.");

                // If Category key does not exist, creates new ObservableCollection<ProductViewModel> at Category key
                if (!CategoryProducts.ContainsKey(category)) CategoryProducts[category] = new ObservableCollection<ProductViewModel>();
                
                // Add to CategoryProducts
                CategoryProducts[category].Add(productViewModel);
            }
        }

        public void AddProductsToQuote()
        {
            // Iterates through CategoryProduct Keys (Category) and Values (ObservableCollection<ProductViewModel>)
            foreach (Category category in CategoryProducts.Keys)
            {
                foreach (ProductViewModel product in CategoryProducts[category])
                {
                    if (product.IsSelected)
                    {
                        // Adds Product to QuoteProduct in QuoteViewModel and sets product.IsSelected to false
                        _quoteViewModel.AddQuoteProduct(product.Model);
                        product.IsSelected = false;
                    }
                }
            }
        }
    }
}