using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace KursNBP
{
    [XmlRootAttribute("ExchangeRatesSeries", IsNullable = false)]
    public class ExchangeRatesData
    {
        [XmlElement("Currency")] public string Currency;
        [XmlArrayAttribute("Rates")] public ExchangeRate[] ExchangeRates;
    }

    [XmlType(TypeName = "Rate")]
    public class ExchangeRate
    {
        [XmlElement("No")] public string No;

        [XmlElement("EffectiveDate")] public string Date;

        [XmlElement("Mid")] public double Value;
    }
}