using OMS.Interfaces;
using System.Globalization;

namespace OMS.Data
{
 
    public class PriceFormattingService : IPriceFormattingService
        
    {
        private CultureInfo GetCultureInfoForCurrencyCode(string currencyCode)
        {
            switch (currencyCode.ToLower())
            {
                case "tnd":
                    return new CultureInfo("ar-TN");

                default:
                    return CultureInfo.CurrentCulture;
            }
        }
        public string FormatPrice(decimal price, string currencyCode)
        {
            CultureInfo cultureInfo = GetCultureInfoForCurrencyCode(currencyCode);

            NumberFormatInfo nfi = cultureInfo.NumberFormat;

            nfi.CurrencySymbol = cultureInfo.NumberFormat.CurrencySymbol;

            return price.ToString("C", nfi);
        }
    }
   
}
