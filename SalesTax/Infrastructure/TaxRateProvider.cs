using System;
using Domain;
using Domain.Interfaces;

namespace Infrastructure
{
    public class TaxRateProvider : ITaxRateProvider
    {
        public decimal GetBasicSalesTaxRate()
        {
            try
            {
                //potentially call to an external web service (bank or government etc)
                return 0.1m;
            }
            catch (Exception ex)
            {
                throw new TaxRateProviderException("Cannot get basic sales tax rate", ex);
            }
        }

        public decimal GetImportDutySalesTaxRate()
        {
            try
            {
                //potentially call to an external web service (bank or government etc)
                return 0.05m;
            }
            catch (Exception ex)
            {
                throw new TaxRateProviderException("Cannot get import duty tax rate", ex);
            }
        }
    }
}