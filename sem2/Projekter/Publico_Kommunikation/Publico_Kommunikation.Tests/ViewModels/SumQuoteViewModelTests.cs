using Moq;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class SumQuoteViewModelTests
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
        
        [TestMethod]
        public void HourlyRateIsReadOnly_ReturnsTrue()
        {
            // Act
            var sumQuoteViewModel = new SumQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual(true, sumQuoteViewModel.HourlyRateIsReadOnly);
        }

        [TestMethod]
        public void SumIsReadOnly_ReturnsFalse()
        {
            // Act
            var sumQuoteViewModel = new SumQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual(false, sumQuoteViewModel.SumIsReadOnly);
        }

        [TestMethod]
        public void Constructor_SwitchTextHasCorrectValue()
        {
            // Act
            var sumQuoteViewModel = new SumQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual("Konvertér Til Fast Timepris", sumQuoteViewModel.SwitchText);
        }

        // ----------- UpdatePrice Tests ----------
        [TestMethod]
        public void UpdatePrice_WhenSumChanged_UpdatesHourlyRateAndQuoteProductPrices()
        {
            // Arrange
            var sumQuoteViewModel = UpdatePriceArrange();

            // Act
            sumQuoteViewModel.Sum = 16800;

            // Assert
            Assert.AreEqual(1400, sumQuoteViewModel.HourlyRate);
            Assert.AreEqual(5600, sumQuoteViewModel.QuoteProducts[0].QuoteProductPrice);
            Assert.AreEqual(11200, sumQuoteViewModel.QuoteProducts[1].QuoteProductPrice);
        }

        [TestMethod]
        public void UpdatePrice_WhenQuoteProductTimeEstimateChanged_UpdatesHourlyRateAndQuoteProductPrices()
        {
            // Arrange
            var sumQuoteViewModel = UpdatePriceArrange();
            sumQuoteViewModel.Sum = 18000;

            // Act
            sumQuoteViewModel.QuoteProducts[0].QuoteProductTimeEstimate = 10;

            // Assert
            Assert.AreEqual(1000, sumQuoteViewModel.HourlyRate);
            Assert.AreEqual(10000, sumQuoteViewModel.QuoteProducts[0].QuoteProductPrice);
            Assert.AreEqual(8000, sumQuoteViewModel.QuoteProducts[1].QuoteProductPrice);
        }

        [TestMethod]
        public void UpdatePrice_WhenDiscountPercentageGiven_UpdatesDiscountedSum()
        {
            // Arrange
            var sumQuoteViewModel = UpdatePriceArrange();
            sumQuoteViewModel.Sum = 20000;

            // Act
            sumQuoteViewModel.DiscountPercentage = 20;

            // Assert
            Assert.AreEqual(16000, sumQuoteViewModel.DiscountedSum);
        }

        // ----------- Sum Tests ----------
        [TestMethod]
        public void Sum_WhenSetToNegative_DoesNotUpdate()
        {
            // Arrange
            var SumQuoteViewModel = UpdatePriceArrange();
            SumQuoteViewModel.Sum = 100;

            // Act
            SumQuoteViewModel.Sum = -500;

            // Assert
            Assert.AreEqual(100, SumQuoteViewModel.Sum);
        }

        [TestMethod]
        public void Sum_WhenSetToZero_UpdatesValue()
        {
            // Arrange
            var SumQuoteViewModel = UpdatePriceArrange();
            SumQuoteViewModel.Sum = 100;

            // Act
            SumQuoteViewModel.Sum = 0;

            // Assert
            Assert.AreEqual(0, SumQuoteViewModel.Sum);
        }

        [TestMethod]
        public void Sum_WhenSetToPositive_UpdatesValue()
        {
            // Arrange
            var SumQuoteViewModel = UpdatePriceArrange();
            SumQuoteViewModel.Sum = 100;

            // Act
            SumQuoteViewModel.Sum = 500;

            // Assert
            Assert.AreEqual(500, SumQuoteViewModel.Sum);
        }

        // ---------- Helper Methods -----------
        private SumQuoteViewModel UpdatePriceArrange()
        {
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Create Products and setup mockProductRepository to return specific Products by id
            var product1 = new Product { ProductId = 1, ProductName = "TestProduct1" };
            var product2 = new Product { ProductId = 2, ProductName = "TestProduct2" };
            mockProductRepository.Setup(repo => repo.GetByKey(1)).Returns(product1);
            mockProductRepository.Setup(repo => repo.GetByKey(2)).Returns(product2);

            // Create QuoteProducts and setup mockQuoteProductRepository to return QuoteProducts by a specific QuoteId
            var quoteProduct1 = new QuoteProduct { QuoteId = 1, ProductId = 1, QuoteProductTimeEstimate = 4 };
            var quoteProduct2 = new QuoteProduct { QuoteId = 1, ProductId = 2, QuoteProductTimeEstimate = 8 };
            mockQuoteProductRepository.Setup(repo => repo.GetByKeyOne(1)).Returns(new List<QuoteProduct>() { quoteProduct1, quoteProduct2 });

            var sumQuoteViewModel = new SumQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            sumQuoteViewModel.InitializeQuote(quote);

            return sumQuoteViewModel;
        }
    }
}