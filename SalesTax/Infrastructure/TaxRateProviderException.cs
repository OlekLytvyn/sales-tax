using System;

namespace Infrastructure
{
    public class TaxRateProviderException : Exception
    {
        public TaxRateProviderException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
