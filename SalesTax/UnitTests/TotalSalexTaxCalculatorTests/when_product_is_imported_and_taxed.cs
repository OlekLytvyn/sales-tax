using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.ImportDutySalesTaxCalculation;

namespace UnitTests.TotalSalexTaxCalculatorTests
{
    [TestClass]
    public class when_product_is_imported_and_taxed : TotalSalesTaxCalculationTests
    {
        [TestInitialize]
        public void InitProduct()
        {
            _product = new Product(ProductType.Perfume, "Imported bottle of parfume");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, true, 47.50m);
        }

        [TestMethod]
        public void ShouldCalculateTotalSalesTax()
        {
            var expected = 7.125m;
            var actual = _calculator.GetTaxAmount(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPrice()
        {
            var expected = 54.65m;
            var actual = _calculator.GetPriceWithTaxIncluded(_shoppingCartItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateShoppingCartPrice()
        {
            var expected = 54.65m;
            var actual = _shoppingCartItem.GetItemPrice();

            Assert.AreEqual(expected, actual);
        }
    }
}
