using System;
using Domain.Entities;

namespace Domain
{
    abstract public class SalesTaxCalculator
    {
        public abstract decimal GetTaxAmount(ShoppingCartItem product);

        public decimal GetPriceWithTaxIncluded(ShoppingCartItem product)
        {
            return product.BasePrice + RoundUp(GetTaxAmount(product));
        }

        private decimal RoundUp(decimal amount)
        {
            //0.05 is 1/20
            return Math.Ceiling(amount * 20)/20;
        }
    }
}
