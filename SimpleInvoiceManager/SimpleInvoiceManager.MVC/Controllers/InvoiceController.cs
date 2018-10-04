using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoiceManager.Models.Database;

namespace SimpleInvoiceManager.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(Invoice invoice)
        {
            return View(invoice);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchInvoice(Invoice invoice)
        {
            return View(invoice);
        }
    }
}