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
            var mainViewModel = new MainViewModel(null);
        }

        [TestMethod]
        public void Constructor_ValidNavigationService_InitializesShowQuoteOverviewCommand()
        {
            // Act
            var mainViewModel = new MainViewModel(mockNavigation.Object);

            // Assert
            Assert.IsNotNull(mainViewModel.ShowQuoteOverviewCommand);
            Assert.IsTrue(mainViewModel.ShowQuoteOverviewCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShowQuoteOverviewCommand_Execute_ResetsViewsAndInitializesQuotesView()
        {
            // Arrange
            var mainViewModel = new MainViewModel(mockNavigation.Object);
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };

            mockNavigation.Setup(navigation => navigation.NavigateTo<QuotesViewModel>(It.IsAny<Action<QuotesViewModel>>()))
                .Returns(new QuotesViewModel(mockQuoteRepository.Object));

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