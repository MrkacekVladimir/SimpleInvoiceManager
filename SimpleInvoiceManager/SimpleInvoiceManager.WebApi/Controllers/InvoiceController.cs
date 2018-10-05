using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SimpleInvoiceManager.DAO;
using SimpleInvoiceManager.Models.Database;
using SimpleInvoiceManager.WebApi.Helpers;

namespace SimpleInvoiceManager.WebApi.Controllers
{    
    public class InvoiceController : Controller
    {
        #region Constructor & readonly properties
        public InvoiceController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
        }

        private readonly DatabaseContext _context;
        #endregion

        public async Task<JsonResult> GetAll()
        {
            List<Invoice> invoices = await _context.Invoices.ToListAsync();
            return Json(invoices);
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Invoice invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.ID == id);
            return Json(invoice);
        }        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Invoice invoice)
        {                                    
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetNotPaid()
        {
            List<Invoice> invoices = await _context.Invoices.Where(x => x.PaymentStatus == false).ToListAsync();
            return Json(invoices);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> PayInvoiceByID(int? id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Invoice invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.ID == id);
            invoice.PaymentStatus = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}