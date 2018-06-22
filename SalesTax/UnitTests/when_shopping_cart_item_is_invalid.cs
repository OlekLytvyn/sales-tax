using System;
using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class when_shopping_cart_item_is_invalid
    {

        protected Mock<ITaxRateProvider> _taxProviderMock;
        protected SalesTaxCalculator _calculator;
        protected ShoppingCartItem _shoppingCartItem;
        protected Product _product;

        [TestInitialize]
        public virtual void Init()
        {
            _taxProviderMock = new Mock<ITaxRateProvider>();
            _calculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator>
            {
                new BasicSalesTaxCalculator(_taxProviderMock.Object),
                new ImportDutySalesTaxCalculator(_taxProviderMock.Object)
            });

            _product = new Product(ProductType.Music, "1 music CD");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenCalculatorIsNull()
        {
            new ShoppingCartItem(null, _product, false, 14.99m);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenProductIsNull()
        {
            new ShoppingCartItem(_calculator, null, false, 14.99m);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenPriceIsNegative()
        {
            new ShoppingCartItem(_calculator, _product, false, -14.99m);
        }
    }
}
