using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleInvoiceManager.Models.Database;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInvoiceManager.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor & readonly properties

        private readonly HttpClient _client;
        public HomeController(HttpClient client)
        {
            _client = client;
        }

        #endregion

        #region HttpGet Actions
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync("invoice/getall");
            string content = await response.Content.ReadAsStringAsync();
            List<Invoice> Invoices = JsonConvert.DeserializeObject<List<Invoice>>(content);
            return View(Invoices);
        }

        #endregion
    }
}
