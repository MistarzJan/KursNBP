using System;
using System.Threading.Tasks;

namespace KursNBP
{
    class Program
    {
        static async Task Main()
        {
            var currency = "EUR";
            var startDate = "2019-01-01";
            var endDate = "2019-12-12";

            ExchangeRateService exchangeRateService = new ExchangeRateService();
            exchangeRateService.SetVariables(currency, startDate, endDate);
            await exchangeRateService.GetExchangeRates();

            foreach (ExchangeRate exchangeRate in exchangeRateService.ExchangeRatesData.ExchangeRates)
            {
                Console.WriteLine(exchangeRate.Date);
            }
        }
    }
}