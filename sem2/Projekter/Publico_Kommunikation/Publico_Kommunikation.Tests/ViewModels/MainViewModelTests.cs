using Moq;
using Publico_Kommunikation.Services;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class MainViewModelTests
    {
        private Mock<INavigationService> mockNavigation;

        [TestInitialize]
        public void TestInitialize()
        {
            mockNavigation = new Mock<INavigationService>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullNavigationService_ThrowsArgumentNullException()
        {
            // Act
            var mainViewModel = new MainViewModel(null);
        }

        public void Constructor_ValidNavigationServiceAndQuoteRepository_InitializesShowQuoteOverviewCommand()
        {
            // Act
            var mainViewModel = new MainViewModel(mockNavigation.Object);

            // Assert
            Assert.IsNotNull(mainViewModel.ShowQuoteOverviewCommand);
            Assert.IsTrue(mainViewModel.ShowQuoteOverviewCommand.CanExecute(null));
        }

        public void ShowQuoteoverviewCommand_Execute_ResetsViewsAndInitializesQuotesView()
        {
            // Arrange
            var mainViewModel = new MainViewModel(mockNavigation.Object);
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            // Act
            mainViewModel.ShowQuoteOverviewCommand.Execute(null);

            // Assert
            Assert.IsNull(mainViewModel.QuoteViewModel);
            Assert.IsNull(mainViewModel.ProductsViewModel);
            Assert.IsNotNull(mainViewModel.QuotesViewModel);
            Assert.AreEqual(typeof(QuotesViewModel), mainViewModel.QuotesViewModel.GetType());
        }
    }
}