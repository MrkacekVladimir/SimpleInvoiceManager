using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleInvoiceManager.Models.Database
{
    public class Invoice
    {
        public Invoice()
        {
            Items = new List<InvoiceItem>();
        }
        public int ID { get; set; }
        public int InvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public int Tax { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<InvoiceItem> Items { get; set; }
        public Customer Customer { get; set; }        
    }
}
