using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publico_Kommunikation.MVVM.ViewModels;
using Moq;
using System.Collections.ObjectModel;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.Core;

namespace Publico_Kommunikation.Tests
{
    [TestClass]
    public class HourlyRateQuoteViewModelTests
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
        public void SumIsReadOnly_ReturnsTrue()
        {
            // Act
            var hourlyRateQuoteViewModel = new HourlyRateQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual(true, hourlyRateQuoteViewModel.SumIsReadOnly);
        }

        [TestMethod]
        public void HourlyRateIsReadOnly_ReturnsFalse()
        {
            // Act
            var hourlyRateQuoteViewModel = new HourlyRateQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual(false, hourlyRateQuoteViewModel.HourlyRateIsReadOnly);
        }

        [TestMethod]
        public void Constructor_SwitchTextHasCorrectValue()
        {
            // Act
            var hourlyRateQuoteViewModel = new HourlyRateQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);

            // Assert
            Assert.AreEqual("Konvertér Til Fast Totalpris", hourlyRateQuoteViewModel.SwitchText);
        }

        // ----------- UpdatePrice Tests ----------
        [TestMethod]
        public void UpdatePrice_WhenHourlyRateChanged_UpdatesSumAndQuoteProductPrices()
        {
            // Arrange
            var hourlyRateQuoteViewModel = UpdatePriceArrange();

            // Act
            hourlyRateQuoteViewModel.HourlyRate = 1400;

            // Assert
            Assert.AreEqual(16800, hourlyRateQuoteViewModel.Sum);
            Assert.AreEqual(5600, hourlyRateQuoteViewModel.QuoteProducts[0].QuoteProductPrice);
            Assert.AreEqual(11200, hourlyRateQuoteViewModel.QuoteProducts[1].QuoteProductPrice);
        }

        [TestMethod]
        public void UpdatePrice_WhenQuoteProductTimeEstimateChanged_UpdatesSumAndQuoteProductPrices()
        {
            // Arrange
            var hourlyRateQuoteViewModel = UpdatePriceArrange();
            hourlyRateQuoteViewModel.HourlyRate = 1000;

            // Act
            hourlyRateQuoteViewModel.QuoteProducts[0].QuoteProductTimeEstimate = 10;

            // Assert
            Assert.AreEqual(18000, hourlyRateQuoteViewModel.Sum);
            Assert.AreEqual(10000, hourlyRateQuoteViewModel.QuoteProducts[0].QuoteProductPrice);
            Assert.AreEqual(8000, hourlyRateQuoteViewModel.QuoteProducts[1].QuoteProductPrice);
        }

        [TestMethod]
        public void UpdatePrice_WhenDiscountPercentageGiven_UpdatesDiscountedSum()
        {
            // Arrange
            var hourlyRateQuoteViewModel = UpdatePriceArrange();
            hourlyRateQuoteViewModel.HourlyRate = 1500;

            // Act
            hourlyRateQuoteViewModel.DiscountPercentage = 20;

            // Assert
            Assert.AreEqual(14400, hourlyRateQuoteViewModel.DiscountedSum);
        }

        // ---------- Helper Methods -----------
        private HourlyRateQuoteViewModel UpdatePriceArrange()
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

            var hourlyRateQuoteViewModel = new HourlyRateQuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            hourlyRateQuoteViewModel.InitializeQuote(quote);

            return hourlyRateQuoteViewModel;
        }
    }
}