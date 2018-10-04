using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleInvoiceManager.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}