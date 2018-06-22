using Domain.Entities;
using Domain.Interfaces;

namespace Domain
{
    public class ImportDutySalesTaxCalculator : SalesTaxCalculator
    {
        private readonly ITaxRateProvider _taxRateProvider;
        
        public ImportDutySalesTaxCalculator(ITaxRateProvider taxRateProvider)
        {
            _taxRateProvider = taxRateProvider;
        }

        public override decimal GetTaxAmount(ShoppingCartItem item)
        {
            return item.IsImported ? item.BasePrice * _taxRateProvider.GetImportDutySalesTaxRate() : 0.0m;
        }
    }
}
