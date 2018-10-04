using Microsoft.AspNetCore.Mvc;

namespace SimpleInvoiceManager.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
