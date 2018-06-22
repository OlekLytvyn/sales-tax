using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ImportDutySalesTaxCalculation
{
    [TestClass]
    public class when_product_is_imported : ImportDutySalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, true, 25.0m);
        }

        [TestMethod]
        public void ShouldCalculateBasicSalesTaxFor()
        {
            var expected = 1.25m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 26.25m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }
    }
}
