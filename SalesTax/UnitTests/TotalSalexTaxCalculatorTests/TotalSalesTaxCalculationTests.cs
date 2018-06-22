using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.TotalSalexTaxCalculatorTests
{
    [TestClass]
    public class TotalSalesTaxCalculationTests
    {
        protected Mock<ITaxRateProvider> _taxProviderMock;
        protected SalesTaxCalculator _calculator;
        protected ShoppingCartItem _shoppingCartItem;
        protected Product _product;

        [TestInitialize]
        public virtual void Init()
        {
            _taxProviderMock = new Mock<ITaxRateProvider>();
            _taxProviderMock.Setup(x => x.GetBasicSalesTaxRate()).Returns(0.1m);
            _taxProviderMock.Setup(x => x.GetImportDutySalesTaxRate()).Returns(0.05m);

            _calculator = new TotalSalesTaxCalculator(new List<SalesTaxCalculator> { 
                new BasicSalesTaxCalculator(_taxProviderMock.Object), 
                new ImportDutySalesTaxCalculator(_taxProviderMock.Object)});           
        }
    }
}
