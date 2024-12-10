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
        private Mock<IQuoteRepository> mockQuoteRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockNavigation = new Mock<INavigationService>();
            mockQuoteRepository = new Mock<IQuoteRepository>();
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