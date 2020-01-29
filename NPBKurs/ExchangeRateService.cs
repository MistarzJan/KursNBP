using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KursNBP
{
    public class ExchangeRateService
    {
        public string Currency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ExchangeRatesData ExchangeRatesData { get; set; }

        IList<ExchangeRate> ExchangeRates { get; set; }

        public void SetVariables(string currency, string startDate, string endDate)
        {
            Currency = currency;
            StartDate = startDate;
            EndDate = endDate;
        }

        public async Task GetExchangeRates()
        {
            RestService restService = new RestService();
            var uri = GenerateRequestUri();
            ExchangeRatesData = await restService.GetExchangeRatesRest(uri);
        }

        string GenerateRequestUri()
        {
            var requestUri = Constants.NBPEndpoint;
            requestUri += $"A/{Currency}/{StartDate}/{EndDate}?format=xml";
            return requestUri;
        }
    }
}