using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class CurrencyConfig
    {
        public string endpoint { get; set; }
        public List<Currency> currencies { get; set; }
    }
}
