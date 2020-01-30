using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursNBP
{
    class Program
    {
        static async Task Main()
        {
            IDictionary<string, double> rate = new Dictionary<string, double>();
            Console.WriteLine("Input Currency");
            var currency = Console.ReadLine();
            if (string.IsNullOrEmpty(currency))
            {
                Console.WriteLine("Currency can't be empty! Input your name once more");
                currency = Console.ReadLine();
            }
            Console.WriteLine("Input Start Date");
            var startDate = Console.ReadLine();
            if (string.IsNullOrEmpty(startDate))
            {
                Console.WriteLine("Start Date can't be empty! Input your name once more");
                startDate = Console.ReadLine();
            }
            Console.WriteLine("Input End Date");
            var endDate = Console.ReadLine();
            if (string.IsNullOrEmpty(endDate))
            {
                Console.WriteLine("End Date can't be empty! Input your name once more");
                endDate = Console.ReadLine();
            }
            double sum = 0;
            double average = 0;
            double standardDeviationSum = 0;
            double standardDeviation = 0;
            double minimumValue = 0;
            double maximumValue = 0;
            var minDate = "";
            var maxDate = "";

            ExchangeRateService exchangeRateService = new ExchangeRateService();
            exchangeRateService.SetVariables(currency, startDate, endDate);
            await exchangeRateService.GetExchangeRates();
            try
            {

                foreach (ExchangeRate exchangeRate in exchangeRateService.ExchangeRatesData.ExchangeRates)
                {
                    rate.Add(new KeyValuePair<string, double>(exchangeRate.Date, exchangeRate.Value));
                    sum += exchangeRate.Value;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Seems That You have entered invalid data, Please try again");
                Main();
            }

            average = sum / rate.Count;

            foreach (KeyValuePair<string, double> entry in rate)
            {
                standardDeviationSum += Math.Pow((entry.Value - average), 2);
            }
            standardDeviation = Math.Sqrt(standardDeviationSum / rate.Count);
            try
            {
                 minimumValue = rate.Values.Min();
                 maximumValue = rate.Values.Max();
                 minDate = rate.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                 maxDate = rate.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                Console.WriteLine("");
                Console.WriteLine($"{minDate} with value of: {minimumValue}");
                Console.WriteLine($"{maxDate} with value of: {maximumValue}");
                Console.WriteLine($"Average Rate: {average}");
                Console.WriteLine($"Standad Deviation: {standardDeviation}");
                Console.WriteLine($"Minimum Value: {minimumValue}");
                Console.WriteLine($"Maximum Value: {maximumValue}");

                Console.ReadLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Seems That You have entered invalid data, Please try again");
                Main();
            }
        }
    }
}