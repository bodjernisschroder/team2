using Moq;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class ProductsViewModelTests
    {
        private Mock<ISimpleKeyRepository<Category>> mockCategoryRepository;
        private Mock<ISimpleKeyRepository<Product>> mockProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockCategoryRepository = new Mock<ISimpleKeyRepository<Category>>();
            mockProductRepository = new Mock<ISimpleKeyRepository<Product>>();
        }

        // ---------- Constructor Tests ----------
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCategoryRepository_ThrowsArgumentNullException()
        {
            // Act
            var productsViewModel = new ProductsViewModel(null, mockProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullProductRepository_ThrowsArgumentNullException()
        {
            // Act
            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, null);
        }

        [TestMethod]
        public void Constructor_ValidEmptyRepositories_InitializesProductsViewModel()
        {
            // Act
            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, mockProductRepository.Object);
            
            // Assert
            Assert.IsNotNull(productsViewModel);
            Assert.IsNotNull(productsViewModel.CategoryProducts);
            Assert.IsNotNull(productsViewModel.AddProductsToQuoteCommand);
            Assert.AreEqual(0, productsViewModel.CategoryProducts.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Constructor_NoMatchingCategoryForProduct_ThrowsKeyNotFoundException()
        {
            // Arrange
            // Create Categories and setup mockCategoryRepository to return specific Categories by id
            var category1 = new Category { CategoryId = 1, CategoryName = "TestCategory1" };
            var category2 = new Category { CategoryId = 2, CategoryName = "TestCategory2" };
            mockCategoryRepository.Setup(repo => repo.GetAll()).Returns(new List<Category> { category1, category2 });

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1", CategoryId = 1 };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2", CategoryId = 1 };
            var product3 = new Product { ProductId = 3, ProductName = "TestProduct3", CategoryId = 3 };
            mockProductRepository.Setup(repo => repo.GetAll()).Returns(new List<Product> { product1, product2, product3 });

            // Act
            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, mockProductRepository.Object);
        }

        [TestMethod]
        public void Constructor_MatchingCategoriesAndProducts_AddsCategoriesAndProductsToCategoryProducts()
        {
            // Arrange
            // Create Categories and setup mockCategoryRepository to return specific Categories by id
            var category1 = new Category { CategoryId = 1, CategoryName = "TestCategory1" };
            var category2 = new Category { CategoryId = 2, CategoryName = "TestCategory2" };
            mockCategoryRepository.Setup(repo => repo.GetAll()).Returns(new List<Category> { category1, category2 });

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1", CategoryId = 1 };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2", CategoryId = 1 };
            var product3 = new Product { ProductId = 3, ProductName = "TestProduct3" , CategoryId = 2 };
            mockProductRepository.Setup(repo => repo.GetAll()).Returns(new List<Product> { product1, product2, product3 });

            // Act
            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, mockProductRepository.Object);
            
            // Assert
            Assert.AreEqual(2, productsViewModel.CategoryProducts.Count);
            Assert.AreEqual(2, productsViewModel.CategoryProducts[category1].Count);
            Assert.AreEqual(1, productsViewModel.CategoryProducts[category2].Count);
            Assert.AreEqual("TestCategory1", productsViewModel.CategoryProducts.Keys.ElementAt(0).CategoryName);
            Assert.AreEqual("TestCategory2", productsViewModel.CategoryProducts.Keys.ElementAt(1).CategoryName);
            Assert.AreEqual("TestProduct1", productsViewModel.CategoryProducts[category1].ElementAt(0).ProductName);
            Assert.AreEqual("TestProduct2", productsViewModel.CategoryProducts[category1].ElementAt(1).ProductName);
            Assert.AreEqual("TestProduct3", productsViewModel.CategoryProducts[category2].ElementAt(0).ProductName);
        }

        // ---------- AddProductsToQuote Tests ----------
        [TestMethod]
        public void AddProductsToQuote_ProductIsSelected_ReturnsFalse()
        {
            // Arrange
            // Create Categories and setup mockCategoryRepository to return all Categories
            var category1 = new Category { CategoryId = 1, CategoryName = "TestCategory1" };
            var category2 = new Category { CategoryId = 2, CategoryName = "TestCategory2" };
            mockCategoryRepository.Setup(repo => repo.GetAll()).Returns(new List<Category> { category1, category2 });

            // Create Products and setup mockProductRepository to return all Products and specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1", CategoryId = 1 };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2", CategoryId = 1 };
            var product3 = new Product { ProductId = 3, ProductName = "TestProduct3", CategoryId = 2 };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);
            mockProductRepository.Setup(repo => repo.GetByKey(3)).Returns(product3);
            mockProductRepository.Setup(repo => repo.GetAll()).Returns(new List<Product> { product1, product2, product3 });

            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, mockProductRepository.Object);

            // Setup and initialize quoteViewModel and quote
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var mockQuoteRepository = new Mock<IQuoteRepository>();
            var mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);
            productsViewModel.InitializeQuoteViewModel(quoteViewModel);

            // Act
            productsViewModel.CategoryProducts[category1].ElementAt(0).IsSelected = true;
            productsViewModel.CategoryProducts[category1].ElementAt(1).IsSelected = true;
            productsViewModel.AddProductsToQuote();

            // Assert
            Assert.IsFalse(productsViewModel.CategoryProducts[category1].ElementAt(0).IsSelected);
            Assert.IsFalse(productsViewModel.CategoryProducts[category1].ElementAt(1).IsSelected);
        }

        // ---------- ClearSelection ----------
        public void ClearSelection_ProductIsSelected_ReturnsFalse()
        {
            // Arrange
            // Create Categories and setup mockCategoryRepository to return all Categories
            var category1 = new Category { CategoryId = 1, CategoryName = "TestCategory1" };
            var category2 = new Category { CategoryId = 2, CategoryName = "TestCategory2" };
            mockCategoryRepository.Setup(repo => repo.GetAll()).Returns(new List<Category> { category1, category2 });

            // Create Products and setup mockProductRepository to return all Products and specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1", CategoryId = 1 };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2", CategoryId = 1 };
            var product3 = new Product { ProductId = 3, ProductName = "TestProduct3", CategoryId = 2 };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);
            mockProductRepository.Setup(repo => repo.GetByKey(3)).Returns(product3);
            mockProductRepository.Setup(repo => repo.GetAll()).Returns(new List<Product> { product1, product2, product3 });

            var productsViewModel = new ProductsViewModel(mockCategoryRepository.Object, mockProductRepository.Object);

            // Setup and initialize quoteViewModel and quote
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var mockQuoteRepository = new Mock<IQuoteRepository>();
            var mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);
            productsViewModel.InitializeQuoteViewModel(quoteViewModel);

            // Act
            productsViewModel.CategoryProducts[category1].ElementAt(0).IsSelected = true;
            productsViewModel.CategoryProducts[category1].ElementAt(1).IsSelected = true;
            productsViewModel.ClearSelection();

            // Assert
            Assert.IsFalse(productsViewModel.CategoryProducts[category1].ElementAt(0).IsSelected);
            Assert.IsFalse(productsViewModel.CategoryProducts[category1].ElementAt(1).IsSelected);
        }
    }
}