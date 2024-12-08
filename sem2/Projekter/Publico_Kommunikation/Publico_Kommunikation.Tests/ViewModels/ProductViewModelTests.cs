using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publico_Kommunikation.MVVM.ViewModels;
using Moq;
using System.Collections.ObjectModel;
using Publico_Kommunikation.DataAccess;
using Publico_Kommunikation.MVVM.Models;
using Publico_Kommunikation.Core;
using Publico_Kommunikation.Services;

namespace Publico_Kommunikation.Tests.ViewModels
{
    [TestClass]
    public class ProductViewModelTests
    {
        [TestInitialize]
        public void TestInitialize() { }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullProduct_ThrowsArgumentNullException()
        {
            // Act
            var productViewModel = new ProductViewModel(null);
        }

        [TestMethod]
        public void Constructor_ValidProduct_ProductViewModelIsInitialized()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "TestProduct" };

            // Act
            var productViewModel = new ProductViewModel(product);

            // Assert
            Assert.IsNotNull(productViewModel);
            Assert.IsNotNull(productViewModel.Model);
            Assert.AreEqual("TestProduct", productViewModel.ProductName);
        }
    }
}
