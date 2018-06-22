using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.ImportDutySalesTaxCalculation;

namespace UnitTests.TotalSalexTaxCalculatorTests
{
    [TestClass]
    public class when_product_is_imported_and_exempt : TotalSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Food, "Imported box of chocolate");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, true, 10.00m);
        }

        [TestMethod]
        public void ShouldCalculateTotalSalesTax()
        {
            var expected = 0.5m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 10.50m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateShoppingCartPrice()
        {
            var expected = 10.50m;
            var actual = _shoppingCartItem.GetItemPrice();

            Assert.AreEqual(expected, actual);
        }
    }
}
