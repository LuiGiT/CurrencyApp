using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp
{
    public class CurrencyPurchase
    {
        public async Task<string> getCurrencyPurchase(string userId, double amount, string iso)
        {
            CurrencyExchange ce = new CurrencyExchange();
            var currRate = await ce.calculateExchange(iso);
            if (currRate.success)
                return (amount / double.Parse(currRate.response)).ToString();
            else
                return currRate.errorMessage;
        }
    }
}
