using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.TotalSalexTaxCalculatorTests
{
    [TestClass]
    public class when_product_is_local_and_taxed : TotalSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Music, "1 music CD");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 14.99m);
        }

        [TestMethod]
        public void ShouldCalculateTotalSalesTaxFor()
        {
            var expected = 1.499m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 16.49m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateShoppingCartPrice()
        {
            var expected = 16.49m;
            var actual = _shoppingCartItem.GetItemPrice();

            Assert.AreEqual(expected, actual);
        }
    }
}
