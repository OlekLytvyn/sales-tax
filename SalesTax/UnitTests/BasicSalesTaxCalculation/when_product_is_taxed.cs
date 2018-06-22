using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TaxCalculation;

namespace UnitTests.BasicSalesTaxCalculation
{
    [TestClass]
    public class when_product_is_taxed : BasicSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Perfume, "Chanel #5");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 25.0m);
        }

        [TestMethod]
        public void ShouldCalculateBasicSalesTaxFor()
        {
            var expected = 2.5m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 27.5m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }
    }
}
