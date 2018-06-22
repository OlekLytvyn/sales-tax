using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ImportDutySalesTaxCalculation
{
    [TestClass]
    public class when_product_is_local : ImportDutySalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 25.0m);
        }

        [TestMethod]
        public void ShouldCalculateBasicSalesTaxFor()
        {
            var expected = 0.0m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 25.0m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }
    }
}
