using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publico_Kommunikation.MVVM.ViewModels;
using Moq;
using System.Collections.ObjectModel;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.Services;

namespace Publico_Kommunikation.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        private Mock<IQuoteRepository> mockQuoteRepository;
        private Mock<INavigationService> mockNavigation;

        [TestInitialize]
        public void TestInitialize()
        {
            mockQuoteRepository = new Mock<IQuoteRepository>();
            mockNavigation = new Mock<INavigationService>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullNavigationService_ThrowsArgumentNullException()
        {
            // Act
            var mainViewModel = new MainViewModel(null, mockQuoteRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuoteRepository_ThrowsArgumentNullException()
        {
            // Act
            var mainViewModel = new MainViewModel(mockNavigation.Object, null);
        }

        public void Constructor_ValidNavigationServiceAndQuoteRepository_InitializesShowQuoteOverviewCommand()
        {
            // Act
            var mainViewModel = new MainViewModel(mockNavigation.Object, mockQuoteRepository.Object);

            // Assert
            Assert.IsNotNull(mainViewModel.ShowQuoteOverviewCommand);
            Assert.IsTrue(mainViewModel.ShowQuoteOverviewCommand.CanExecute(null));
        }

        public void ShowQuoteoverviewCommand_Execute_ResetsViewsAndInitializesQuotesView()
        {
            // Arrange
            var mainViewModel = new MainViewModel(mockNavigation.Object, mockQuoteRepository.Object);
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Act
            mainViewModel.ShowQuoteOverviewCommand.Execute(null);

            // Assert
            Assert.IsNull(mainViewModel.QuoteView);
            Assert.IsNull(mainViewModel.ProductsView);
            Assert.IsNotNull(mainViewModel.QuotesView);
            Assert.AreEqual(typeof(QuotesViewModel), mainViewModel.QuotesView.GetType());
        }
    }
}