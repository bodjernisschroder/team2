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

        /// <summary>
        /// Initializes a new instance of <see cref="ProductsViewModel"/>.
        /// Assigns the specified repositories, calls the <see cref="InitializeCategoryProducts"/>
        /// method, and configures the <see cref="AddProductsToQuoteCommand"/> command.
        /// </summary>
        /// <param name="categoryRepository">The repository for managing <see cref="Category"/> instances.</param>
        /// <param name="productRepository">The repository for managing <see cref="Product"/> instances.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="categoryRepository"/> or <paramref name="productRepository"/> is <c>null</c>.</exception>
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

        /// <summary>
        /// Assigns the specified <paramref name="quoteViewModel"/> to the <see cref="_quoteViewModel"/> field.
        /// </summary>
        /// <param name="quoteViewModel">The <see cref="QuoteViewModel"/> instance to assign to <see cref="_quoteViewModel"/>.</param>
        public void InitializeQuoteViewModel(QuoteViewModel quoteViewModel)
        {
            _quoteViewModel = quoteViewModel;
        }

        /// <summary>
        /// Initializes and populates the <see cref="CategoryProducts"/> collection with all categories
        /// and products from their respective repositories.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Thrown when no <see cref="Category.CategoryId"/> matches a <see cref="Product.CategoryId"/>.</exception>
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
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId) ??
                    throw new KeyNotFoundException($"No CategoryId matching '{product.CategoryId}' of Product '{product.ProductId}' found in {categories}.");

                // If Category key does not exist, creates new ObservableCollection<ProductViewModel> at Category key
                if (!CategoryProducts.ContainsKey(category)) { CategoryProducts[category] = new ObservableCollection<ProductViewModel>(); }
                
                // Add to CategoryProducts
                CategoryProducts[category].Add(productViewModel);
            }
        }

        /// <summary>
        /// Iterates through the <see cref="CategoryProducts"/> collection. For each selected
        /// <see cref="ProductViewModel"/>, calls <see cref="QuoteViewModel.AddQuoteProduct(Product)"/>
        /// with its associated <see cref="Product"/>, and resets the selection state of the <see cref="ProductViewModel"/>.
        /// </summary>
        public void AddProductsToQuote()
        {
            foreach (Category category in CategoryProducts.Keys)
            {
                foreach (ProductViewModel product in CategoryProducts[category])
                {
                    if (product.IsSelected)
                    {
                        _quoteViewModel.AddQuoteProduct(product.Model);
                        product.IsSelected = false;
                    }
                }
            }
        }
    }
}