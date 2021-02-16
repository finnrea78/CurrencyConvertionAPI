using Currency_Converter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Currency_Converter.Controllers
{
    public class ConversionControl : Controller
    {
        public string Conversion(string AmountFrom, string CurrencyFrom, string CurrencyTo)
        {
            string AmountOut;
            Conversion conversion = new Conversion();
            AmountOut = conversion.SetDisplay(AmountFrom, CurrencyFrom, CurrencyTo);
            return "Conversion: " + AmountOut;


        }


    }
}
