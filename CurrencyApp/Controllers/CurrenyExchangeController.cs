using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrenyExchangeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DollarExchangeByCurrency(string iso)
        {
            if (iso == null) return BadRequest("No currency ISO specified");
            CurrencyExchange ce = new CurrencyExchange();
            var result = await ce.calculateExchange(iso);
            if (result.success)
            {
                return Ok(result.response);
            }
            return BadRequest(result.errorMessage);
        }
    }
}
