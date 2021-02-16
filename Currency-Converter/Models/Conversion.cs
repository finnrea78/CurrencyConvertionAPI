using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class Conversion
    {
        
        public string Out { get; set; }

        public string SetDisplay(string AmountFrom, string CurrencyFrom, string CurrencyTo)
        {
            string conversion = CurrencyFrom + "_" + CurrencyTo;
            var jsonString = LoadCurrency(conversion);
            double Out2 = double.Parse(AmountFrom) * JObject.Parse(jsonString).First.First["val"].ToObject<double>();
            return Out2.ToString();

        }

        public string LoadCurrency(string currencys)
        {

            string url = $"https://free.currconv.com/api/v7/convert?q=" + currencys + "&compact=y&apiKey=4276d543489e5ece6996";
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;

        }

    }
}
