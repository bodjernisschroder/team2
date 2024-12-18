using Moq;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class QuoteViewModelTests
    {
        private Mock<IQuoteRepository> mockQuoteRepository;
        private Mock<ISimpleKeyRepository<Product>> mockProductRepository;
        private Mock<ICompositeKeyRepository<QuoteProduct>> mockQuoteProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockQuoteRepository = new Mock<IQuoteRepository>();
            mockProductRepository = new Mock<ISimpleKeyRepository<Product>>();
            mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();
        }

        // ---------- Constructor Tests ----------
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuoteRepository_ThrowsArgumentNullException()
        {
            // Act
            var quoteViewModel = new QuoteViewModel(null, mockProductRepository.Object, mockQuoteProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullProductRepository_ThrowsArgumentNullException()
        {
            // Act
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, null, mockQuoteProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuoteProductRepository_ThrowsArgumentNullException()
        {
            // Act
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, null);
        }

        [TestMethod]
        public void Constructor_ValidRepositories_ConstructsQuoteViewModel()
        {
            // Act
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.IsNotNull(quoteViewModel);
            Assert.AreEqual(0, quoteViewModel.QuoteProducts.Count);
            Assert.IsNotNull(quoteViewModel.DeleteQuoteProductCommand);
            Assert.IsTrue(quoteViewModel.DeleteQuoteProductCommand.CanExecute(null));
        }

        // ---------- InitializeQuote Tests ----------
        [TestMethod]
        public void InitializeQuote_QuoteIsInitialized_ContainsNoQuoteProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            mockQuoteProductRepository.Setup(repo => repo.GetByKeyOne(It.IsAny<int>())).Returns(new List<QuoteProduct>());

            // Act
            quoteViewModel.InitializeQuote(quote);

            // Assert
            Assert.AreEqual(0, quoteViewModel.QuoteProducts.Count);
            mockQuoteProductRepository.Verify(repo => repo.GetByKeyOne(quoteViewModel.QuoteId), Times.Once);
        }

        [TestMethod]
        public void InitializeQuote_QuoteIsInitialized_ContainsQuoteProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);

            // Create QuoteProducts and setup mockQuoteProductRepository to return all QuoteProducts
            var quoteProduct1 = new QuoteProduct { QuoteId = 1, ProductId = 1, QuoteProductTimeEstimate = 4, QuoteProductPrice = 6000 };
            var quoteProduct2 = new QuoteProduct { QuoteId = 1, ProductId = 2, QuoteProductTimeEstimate = 8, QuoteProductPrice = 12000 };
            mockQuoteProductRepository.Setup(repo => repo.GetByKeyOne(1)).Returns(new List<QuoteProduct>() { quoteProduct1, quoteProduct2 });

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Act
            quoteViewModel.InitializeQuote(quote);

            // Assert
            Assert.AreEqual(1, quoteViewModel.QuoteId);
            Assert.AreEqual("TestQuote", quoteViewModel.QuoteName);

            Assert.AreEqual(2, quoteViewModel.QuoteProducts.Count);
            Assert.AreEqual("TestProduct1", quoteViewModel.QuoteProducts[0].ProductName);
            Assert.AreEqual("TestProduct2", quoteViewModel.QuoteProducts[1].ProductName);
        }

        // ---------- GetAllQuoteProducts Tests ----------
        [TestMethod]
        public void GetAllQuoteProducts_NoAssociatedQuoteProducts_ClearsQuoteProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);

            // Create unrelated QuoteProducts and setup mockQuoteProductRepository to return all QuoteProducts
            var unrelatedQuoteProduct1 = new QuoteProduct { QuoteId = 2, ProductId = 1, QuoteProductTimeEstimate = 4, QuoteProductPrice = 6000 };
            var unrelatedQuoteProduct2 = new QuoteProduct { QuoteId = 2, ProductId = 2, QuoteProductTimeEstimate = 8, QuoteProductPrice = 12000 };
            mockQuoteProductRepository.Setup(repo => repo.GetByKeyOne(2)).Returns(new List<QuoteProduct>());

            var unrelatedQuoteProductViewModel1 = new QuoteProductViewModel(unrelatedQuoteProduct1, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var unrelatedQuoteProductViewModel2 = new QuoteProductViewModel(unrelatedQuoteProduct2, mockProductRepository.Object, mockQuoteProductRepository.Object);

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            // Act
            // Adds QuoteProductViewModels that do not belong to the Quote
            quoteViewModel.QuoteProducts.Add(unrelatedQuoteProductViewModel1);
            quoteViewModel.QuoteProducts.Add(unrelatedQuoteProductViewModel2);

            quoteViewModel.GetAllQuoteProducts();

            // Assert
            Assert.AreEqual(0, quoteViewModel.QuoteProducts.Count);
        }

        [TestMethod]
        public void GetAllQuoteProducts_SomeAssociatedProducts_GetsQuoteProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            // Create QuoteProducts and setup mockQuoteProductRepository to return all QuoteProducts
            var quoteProduct1 = new QuoteProduct { QuoteId = 1, ProductId = 1, QuoteProductTimeEstimate = 4, QuoteProductPrice = 6000 };
            var quoteProduct2 = new QuoteProduct { QuoteId = 1, ProductId = 2, QuoteProductTimeEstimate = 8, QuoteProductPrice = 12000 };
            mockQuoteProductRepository.Setup(repo => repo.GetByKeyOne(1)).Returns(new List<QuoteProduct>() { quoteProduct1, quoteProduct2 });

            // Act
            quoteViewModel.GetAllQuoteProducts();

            // Assert
            Assert.AreEqual(2, quoteViewModel.QuoteProducts.Count);
            Assert.AreEqual("TestProduct1", quoteViewModel.QuoteProducts[0].ProductName);
            Assert.AreEqual("TestProduct2", quoteViewModel.QuoteProducts[1].ProductName);
        }

        // ---------- UpdateQuote Tests ----------
        [TestMethod]
        public void UpdateQuote_CallsUpdateMethodInRepository()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            // Act
            quoteViewModel.UpdateQuote();

            // Assert
            mockQuoteRepository.Verify(repo => repo.Update(quote), Times.Once);
        }

        // ---------- Switch Tests ----------
        [TestMethod]
        public void Switch_InvokesOnSwitchRequestedEvent()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            Quote eventArgument = null;
            var eventInvoked = false;
            quoteViewModel.OnSwitchRequested += q => { eventInvoked = true; eventArgument = q; };

            // Act
            quoteViewModel.Switch();

            // Assert
            Assert.IsTrue(eventInvoked);
            Assert.AreEqual(quote, eventArgument);
        }

        [TestMethod]
        public void SwitchCommand_Execute_InvokesOnSwitchRequestedEvent()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            Quote eventArgument = null;
            var eventInvoked = false;
            quoteViewModel.OnSwitchRequested += q => { eventInvoked = true; eventArgument = q; };

            // Act
            quoteViewModel.SwitchCommand.Execute(null);

            // Assert
            Assert.IsTrue(eventInvoked);
            Assert.AreEqual(quote, eventArgument);
        }

        // ---------- AddQuoteProduct Tests ----------
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddQuoteProduct_NullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            // Act
            quoteViewModel.AddQuoteProduct(null);
        }

        [TestMethod]
        public void AddQuoteProduct_AddProductsAsQuoteProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            // Act
            quoteViewModel.AddQuoteProduct(product1);
            quoteViewModel.AddQuoteProduct(product2);

            // Assert
            Assert.AreEqual(2, quoteViewModel.QuoteProducts.Count);
            Assert.AreEqual("TestProduct1", quoteViewModel.QuoteProducts[0].ProductName);
            Assert.AreEqual("TestProduct2", quoteViewModel.QuoteProducts[1].ProductName);
        }

        [TestMethod]
        public void AddQuoteProduct_SubscribesToOnTimeEstimateChangedEvent()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };

            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product);

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            var eventInvoked = false;

            // Act
            quoteViewModel.AddQuoteProduct(product);
            quoteViewModel.QuoteProducts[0].OnTimeEstimateChanged += () => eventInvoked = true;
            quoteViewModel.QuoteProducts[0].OnTimeEstimateChanged.Invoke();

            // Assert
            Assert.IsTrue(eventInvoked);
        }

        // ---------- DeleteQuoteProduct Tests ----------
        [TestMethod]
        public void DeleteQuoteProduct_DeleteMultipleProducts()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            var product3 = new Product { ProductId = 3, ProductName = "TestProduct3" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);
            mockProductRepository.Setup(repo => repo.GetByKey(3)).Returns(product3);

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel.InitializeQuote(quote);

            var quoteProduct1 = new QuoteProduct { QuoteId = 1, ProductId = 1 };
            var quoteProduct2 = new QuoteProduct { QuoteId = 1, ProductId = 2 };
            var quoteProduct3 = new QuoteProduct { QuoteId = 1, ProductId = 3 };

            var quoteProductViewModel1 = new QuoteProductViewModel(quoteProduct1, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var quoteProductViewModel2 = new QuoteProductViewModel(quoteProduct2, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var quoteProductViewModel3 = new QuoteProductViewModel(quoteProduct3, mockProductRepository.Object, mockQuoteProductRepository.Object);

            quoteViewModel.QuoteProducts.Add(quoteProductViewModel1);
            quoteViewModel.QuoteProducts.Add(quoteProductViewModel2);
            quoteViewModel.QuoteProducts.Add(quoteProductViewModel3);

            // Act
            quoteViewModel.DeleteQuoteProduct(quoteProductViewModel1);
            quoteViewModel.DeleteQuoteProduct(quoteProductViewModel3);

            // Assert
            Assert.AreEqual(1, quoteViewModel.QuoteProducts.Count);
            Assert.AreEqual("TestProduct2", quoteViewModel.QuoteProducts[0].ProductName);
        }

        // ---------- DiscountPercentage Tests -----------
        [TestMethod]
        public void DiscountPercentage_WhenSetOutsideLimit_DoesNotUpdate()
        {
            // Arrange
            var quote1 = new Quote { DiscountPercentage = 10 };
            var quote2 = new Quote { DiscountPercentage = 10 };
            var quoteViewModel1 = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var quoteViewModel2 = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel1.InitializeQuote(quote1);
            quoteViewModel2.InitializeQuote(quote2);

            // Act
            quoteViewModel1.DiscountPercentage = -10;
            quoteViewModel2.DiscountPercentage = 100;

            // Assert
            Assert.AreEqual(10, quoteViewModel1.DiscountPercentage);
            Assert.AreEqual(10, quoteViewModel2.DiscountPercentage);
        }

        [TestMethod]
        public void DiscountPercentage_WhenSetWithinLimit_UpdatesValue()
        {
            // Arrange
            var quote1 = new Quote { DiscountPercentage = 10 };
            var quote2 = new Quote { DiscountPercentage = 10 };
            var quote3 = new Quote { DiscountPercentage = 10 };
            var quoteViewModel1 = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var quoteViewModel2 = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            var quoteViewModel3 = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            quoteViewModel1.InitializeQuote(quote1);
            quoteViewModel2.InitializeQuote(quote2); 
            quoteViewModel3.InitializeQuote(quote3);

            // Act
            quoteViewModel1.DiscountPercentage = 0;
            quoteViewModel2.DiscountPercentage = 25;
            quoteViewModel3.DiscountPercentage = 50;

            // Assert
            Assert.AreEqual(0, quoteViewModel1.DiscountPercentage);
            Assert.AreEqual(25, quoteViewModel2.DiscountPercentage);
            Assert.AreEqual(50, quoteViewModel3.DiscountPercentage);
        }
    }
}