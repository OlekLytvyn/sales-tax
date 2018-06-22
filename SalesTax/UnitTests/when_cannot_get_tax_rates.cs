using System;
using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class when_cannot_get_tax_rates
    {

        protected Mock<ITaxRateProvider> _taxProviderMock;
        protected SalesTaxCalculator _calculator;
        protected ShoppingCartItem _shoppingCartItem;
        protected Product _product;

        [TestInitialize]
        public virtual void Init()
        {
            _taxProviderMock = new Mock<ITaxRateProvider>();
            _taxProviderMock.Setup(x => x.GetBasicSalesTaxRate()).Throws(new TaxRateProviderException(It.IsAny<string>(), new Exception()));
            _taxProviderMock.Setup(x => x.GetImportDutySalesTaxRate()).Returns(0.05m);

            _calculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator>
            {
                new BasicSalesTaxCalculator(_taxProviderMock.Object),
                new ImportDutySalesTaxCalculator(_taxProviderMock.Object)
            });

            _product = new Product(ProductType.Music, "1 music CD");
            _shoppingCartItem = new ShoppingCartItem(_calculator, _product, false, 14.99m);
        }

        [ExpectedException(typeof(TaxRateProviderException))]
        [TestMethod]
        public void ShouldThrowException()
        {
            _shoppingCartItem.GetItemPrice();
        }
    }
}
