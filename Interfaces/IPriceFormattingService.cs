
namespace OMS.Interfaces
{
    public interface IPriceFormattingService
    {
        string FormatPrice(decimal price, string currencyCode);
    }
}
