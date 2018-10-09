using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class InvoiceItem
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }        
        public float Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
