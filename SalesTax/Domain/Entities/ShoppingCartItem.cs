using System;

namespace Domain.Entities
{
    public class ShoppingCartItem
    {
        private readonly SalesTaxCalculator _salesTaxCalculator;
        public decimal BasePrice { get; private set; }
        public Product Product { get; private set; }
        public bool IsImported { get; private set; }

        public ShoppingCartItem(SalesTaxCalculator salesTaxCalculator, Product product, bool isImported, decimal basePrice)
        {
            if (salesTaxCalculator == null || product == null || basePrice < 0)
            {
                throw new ArgumentException("Shopping Cart Item is invalid");
            }

            _salesTaxCalculator = salesTaxCalculator;
            Product = product;
            BasePrice = basePrice;
            IsImported = isImported;
        }

        public decimal GetItemPrice()
        {
            return _salesTaxCalculator.GetPriceWithTaxIncluded(this);
        }
    }
}