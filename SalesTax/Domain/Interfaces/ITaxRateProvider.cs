
namespace Domain.Interfaces
{
    public interface ITaxRateProvider
    {
        decimal GetBasicSalesTaxRate();
        decimal GetImportDutySalesTaxRate();
    }
}
