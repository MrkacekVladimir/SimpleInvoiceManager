 using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleInvoiceManager.Models.Database;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SimpleInvoiceManager.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        #region Constructor & readonly properties

        private readonly HttpClient _client;
        public InvoiceController(HttpClient client)
        {
            _client = client;
        }

        #endregion

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            HttpResponseMessage response = await _client.GetAsync("invoice/getbyid/" + id);
            string content = await response.Content.ReadAsStringAsync();

            return View(JsonConvert.DeserializeObject<Invoice>(content));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StringContent content = new StringContent(JsonConvert.SerializeObject(invoice), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PatchAsync("invoice/patchinvoice", content);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StringContent content = new StringContent(JsonConvert.SerializeObject(invoice), System.Text.Encoding.UTF8, "application/json");            
            HttpResponseMessage response = await _client.PostAsJsonAsync<Invoice>("invoice/create", invoice);

            if(response.StatusCode == System.Net.HttpStatusCode.Created)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> NotPaid()
        {
            HttpResponseMessage response = await _client.GetAsync("invoice/getnotpaid/");
            string content = await response.Content.ReadAsStringAsync();
            List<Invoice> Invoices = JsonConvert.DeserializeObject<List<Invoice>>(content);
            return View(Invoices);
        }


    }
}