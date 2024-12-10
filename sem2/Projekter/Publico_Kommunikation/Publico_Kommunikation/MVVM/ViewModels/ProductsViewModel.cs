using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.MVVM.ViewModels
{
    /// <summary>
    /// A ViewModel class for managing <see cref="Category"/> entities and their
    /// associated <see cref="ProductViewModel"/> instances.
    /// Inherits from <see cref="ViewModel"/> and provides functionality for organizing
    /// products into categories and assigning products to quotes.
    /// </summary>
    public class ProductsViewModel : ViewModel
    {
        private readonly ISimpleKeyRepository<Category> _categoryRepository;
        private readonly ISimpleKeyRepository<Product> _productRepository;
        private QuoteViewModel _quoteViewModel;
        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    ClearSelection();
                    _selectedIndex = value;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }
        }
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
        public ProductsViewModel(ISimpleKeyRepository<Category> categoryRepository, ISimpleKeyRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            
            InitializeCategoryProducts();

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
        /// Iterates through the <see cref="ProductViewModel"/> entities in the currently selected <see cref="Category"/>.
        /// For each selected <see cref="ProductViewModel"/>, calls <see cref="QuoteViewModel.AddQuoteProduct(Product)"/>
        /// with its associated <see cref="Product"/>, and resets the selection state of the <see cref="ProductViewModel"/>.
        /// Displays a <see cref="MessageBox"/> to notify the user in case any of the selected <see cref="ProductViewModel"/> entities are
        /// already associated to the current <see cref="Quote"/>. Duplicates are not added to the <see cref="Quote"/>, while all
        /// other selected <see cref="ProductViewModel"/> entities will be added to the <see cref="Quote"/>.
        /// </summary>
        public void AddProductsToQuote()
        {
            var duplicates = new List<string>();
            Category selectedCategory = CategoryProducts.Keys.ToList()[SelectedIndex];

            foreach (var product in CategoryProducts[selectedCategory])
            {
                if (product.IsSelected)
                {
                    try
                    {
                        _quoteViewModel.AddQuoteProduct(product.Model);
                    }
                    catch (SqlException)
                    {
                        duplicates.Add(product.ProductName);
                    }
                    product.IsSelected = false;
                }
            }
            if (duplicates.Any())
            {
                MessageBox.Show("Disse valgte ydelser findes allerede i tilbuddet:\n\t" + string.Join("\n\t", duplicates) +
                    "\n\nResterende valgte ydelser er blevet korrekt tilføjet til tilbuddet.", "Ydelser findes allerede", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Sets <see cref="ProductViewModel.IsSelected"/> values to false for all <see cref="ProductViewModel"/>
        /// entities in the currently selected <see cref="Category"/>.
        /// </summary>
        public void ClearSelection()
        {
            Category selectedCategory = CategoryProducts.Keys.ToList()[SelectedIndex];
            foreach (var product in CategoryProducts[selectedCategory])
            {
                product.IsSelected = false;
            }
        }
    }
}