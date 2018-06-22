using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.TotalSalexTaxCalculatorTests
{
    [TestClass]
    public class when_product_is_local_and_exempt : TotalSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Medical, "1 bottle of headache pills");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 9.75m);
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
            var expected = 9.75m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateShoppingCartPrice()
        {
            var expected = 9.75m;
            var actual = _shoppingCartItem.GetItemPrice();

            Assert.AreEqual(expected, actual);
        }
    }
}
