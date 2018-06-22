using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TaxCalculation;

namespace UnitTests.BasicSalesTaxCalculation
{
    [TestClass]
    public class when_product_is_exempt : BasicSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Book, ".NET book");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 25.0m);
        }

        [TestMethod]
        public void ShouldCalculateBasicSalesTax()
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
