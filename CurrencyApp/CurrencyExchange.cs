using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using CurrencyApp.Models;

namespace CurrencyApp
{
    public class CurrencyExchange
    {
        HttpClient client = new HttpClient();
        public async Task<double> getTodaysDollarRate()
        {
            try
            {
                HttpResponseMessage request = await client.GetAsync("https://www.bancoprovincia.com.ar/principal/dolar");
                request.EnsureSuccessStatusCode();
                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();
                    var unescaped = response.Replace("\"", "").Replace("[", "");
                    var arr = unescaped.Split(',');
                    var rate = arr[0];
                    double dollarRate = 0;
                    if (double.TryParse(rate, out dollarRate))
                    {
                        return dollarRate;
                    }
                }
                return -1;
            }
            catch
            {
                return -1;
            }

        }

        public async Task<ResponseBody> calculateExchange(string iso)
        {
            ResponseBody rb = new ResponseBody();
            try
            {

                FileStream stream = File.OpenRead("./currency_config.json");
                var json = await JsonSerializer.DeserializeAsync<CurrencyConfig>(stream);
                iso = iso.ToUpper();
                var currency = json.currencies.Where(c => c.iso == iso).FirstOrDefault();
                if (currency != null)
                {
                    double dollarRate = await getTodaysDollarRate();
                    if (dollarRate > 0)
                    {
                        rb.errorMessage = "";
                        rb.success = true;
                        rb.response = ((dollarRate / 100) * currency.rule).ToString();
                    }
                    else
                    {
                        rb.errorMessage = "Couldn't reach currency rate endpoint!";
                        rb.success = false;
                        rb.response = "";
                    }

                }
                else
                {
                    rb.errorMessage = "Currency not supported!";
                    rb.success = false;
                    rb.response = "";
                }

            }
            catch (Exception ex)
            {
                rb.success = false;
                rb.errorMessage = ex.Message;
                rb.response = "";
            }
            return rb;
        }

    }
}
