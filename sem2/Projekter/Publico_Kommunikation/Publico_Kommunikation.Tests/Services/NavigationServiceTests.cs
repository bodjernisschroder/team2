using Moq;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.Services;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.MVVM.ViewModels;

namespace Publico_Kommunikation.Tests.Services
{
    [TestClass]
    public class NavigationServiceTests
    {
        private Mock<Func<Type, ViewModel>> mockViewModelFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            mockViewModelFactory =new Mock<Func<Type, ViewModel>>();
        }

        [TestMethod]
        public void Constructor_InitializesNavigationService()
        {
            // Act
            var navigationService = new NavigationService(mockViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(navigationService);
        }

        [TestMethod]
        public void NavigateTo_RetrievesViewModelFromFactory()
        {
            // Arrange
            var navigationService = new NavigationService(mockViewModelFactory.Object);

            // Initialize QuoteViewModel and setup mockViewModelFactory to return it when called with typeof(QuoteViewModel)
            var mockQuoteRepository = new Mock<IQuoteRepository>();
            var mockProductRepository = new Mock<ISimpleKeyRepository<Product>>();
            var mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            mockViewModelFactory.Setup(factory => factory(typeof(QuoteViewModel))).Returns(quoteViewModel);

            // Act
            var invokedViewModel = navigationService.NavigateTo<QuoteViewModel>();

            // Assert
            Assert.IsNotNull(invokedViewModel);
            Assert.AreSame(quoteViewModel, invokedViewModel);
        }

        [TestMethod]
        public void NavigateTo_WhenInitializerActionProvided_InvokesInitializer()
        {
            // Arrange
            var quote = new Quote { QuoteId = 1, QuoteName = "TestQuote" };
            var navigationService = new NavigationService(mockViewModelFactory.Object);

            // Initialize QuoteViewModel and setup mockViewModelFactory to return it when called with typeof(QuoteViewModel)
            var mockQuoteRepository = new Mock<IQuoteRepository>();
            var mockProductRepository = new Mock<ISimpleKeyRepository<Product>>();
            var mockQuoteProductRepository = new Mock<ICompositeKeyRepository<QuoteProduct>>();

            var quoteViewModel = new QuoteViewModel(mockQuoteRepository.Object, mockProductRepository.Object, mockQuoteProductRepository.Object);
            mockViewModelFactory.Setup(factory => factory(typeof(QuoteViewModel))).Returns(quoteViewModel);

            // Act
            var invokedViewModel = navigationService.NavigateTo<QuoteViewModel>(vm => vm.InitializeQuote(quote));

            // Assert
            Assert.AreEqual("TestQuote", (invokedViewModel as QuoteViewModel).QuoteName);
        }
    }
}
