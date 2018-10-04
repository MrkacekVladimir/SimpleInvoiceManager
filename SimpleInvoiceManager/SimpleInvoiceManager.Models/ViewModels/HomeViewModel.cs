using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
