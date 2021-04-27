using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class ResponseBody
    {
        public string response { get; set; }
        public bool success { get; set; }
        public string errorMessage { get; set; }
    }
}
