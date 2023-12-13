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
                    return new CultureInfo("fr-TN");

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
        public string FormatPrice(double price, string currencyCode)
        {
            CultureInfo cultureInfo = GetCultureInfoForCurrencyCode(currencyCode);

            NumberFormatInfo nfi = cultureInfo.NumberFormat;

            nfi.CurrencySymbol = cultureInfo.NumberFormat.CurrencySymbol;
       

            return price.ToString("C0", nfi);
        }
    }
   
}
