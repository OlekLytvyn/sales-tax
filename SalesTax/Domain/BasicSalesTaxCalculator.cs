using Domain.Entities;
using Domain.Interfaces;

namespace Domain
{
    public class BasicSalesTaxCalculator : SalesTaxCalculator
    {
        public const ProductType ExemptProductCategories = (ProductType.Book | ProductType.Food | ProductType.Medical);
        private readonly ITaxRateProvider _taxRateProvider;

        public BasicSalesTaxCalculator(ITaxRateProvider taxRateProvider)
        {
            _taxRateProvider = taxRateProvider;
        }

        public override decimal GetTaxAmount(ShoppingCartItem item)
        {
            if (ExemptProductCategories.HasFlag(item.Product.Type))
            {
                return 0.0m;
            }

            return item.BasePrice * _taxRateProvider.GetBasicSalesTaxRate();
        }
    }
}
