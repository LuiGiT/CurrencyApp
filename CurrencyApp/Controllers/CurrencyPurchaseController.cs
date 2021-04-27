using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class CurrencyPurchaseController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> purchaseCurrency(string userid, double amount, string iso)
        {
            CurrencyPurchase cp = new CurrencyPurchase();
            var purchase = await cp.getCurrencyPurchase(userid, amount, iso);

            return Ok(purchase);
        }
    }
}
