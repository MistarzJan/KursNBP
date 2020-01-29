using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace KursNBP
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<ExchangeRatesData> GetExchangeRatesRest(string query)
        {
            ExchangeRatesData data = new ExchangeRatesData();

            try
            {
                var response = await _client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync();
                    XmlSerializer serializer = new XmlSerializer(typeof(ExchangeRatesData));
                    data = (ExchangeRatesData) serializer.Deserialize(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex);
            }

            return data;
        }
    }
}