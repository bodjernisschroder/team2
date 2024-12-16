using Moq;
using Publico_Kommunikation.MVVM.ViewModels;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class QuoteProductViewModelTests
    {
        private Mock<ISimpleKeyRepository<Product>> mockProductRepository;
        private Mock<ICompositeKeyRepository<QuoteProduct>> mockQuoteProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockProductRepository = new Mock<ISimpleKeyRepository<Product>>();
            mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuoteProduct_ThrowsArgumentNullException()
        {
            // Act
            var quoteProductViewModel = new QuoteProductViewModel(null, mockProductRepository.Object, mockQuoteProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullProductRepository_ThrowsArgumentNullException()
        {
            // Act
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, null, mockQuoteProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuoteProductRepository_ThrowsArgumentNullException()
        {
            // Arrange
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };

            // Act
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, null);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Constructor_ValidQuoteProductAndRepositories_MatchingProductIdNotFound()
        {
            // Arrange
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns((Product)null);

            // Act
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, mockQuoteProductRepository.Object);
        }


        [TestMethod]
        public void Constructor_ValidQuoteProductAndRepositories_InitializesProductViewModelAndGetsProductName()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product);
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };

            // Act
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.IsNotNull(quoteProductViewModel);
            Assert.IsNotNull(quoteProductViewModel.Model);
            Assert.AreEqual("TestProduct", quoteProductViewModel.ProductName);
        }

        [TestMethod]
        public void UpdateQuoteProduct_CallsUpdateMethodInRepository()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product);
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Act
            quoteProductViewModel.UpdateQuoteProduct();

            // Assert
            mockQuoteProductRepository.Verify(repo => repo.Update(quoteProduct), Times.Once);
        }

        [TestMethod]
        public void UpdateQuoteProductPrice_UpdatesQuoteProductPrice()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product);
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1, QuoteProductTimeEstimate = 5 };
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Act
            quoteProductViewModel.UpdateQuoteProductPrice(1000);

            // Assert
            Assert.AreEqual(5000, quoteProductViewModel.QuoteProductPrice);
        }

        [TestMethod]
        public void QuoteProductTimeEstimate_WhenChanged_InvokesOnTimeEstimateChangedEvent()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product);
            var quoteProduct = new QuoteProduct { QuoteId = 1, ProductId = 1 };
            var quoteProductViewModel = new QuoteProductViewModel(quoteProduct, mockProductRepository.Object, mockQuoteProductRepository.Object);
            
            var eventInvoked = false;
            quoteProductViewModel.OnTimeEstimateChanged += () => eventInvoked = true;

            // Act
            quoteProductViewModel.QuoteProductTimeEstimate = 5;

            // Assert
            Assert.IsTrue(eventInvoked);
        }
    }
}
