using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class InvoiceItem: DatabaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float PricePerUnit { get; set; }        
        public float Total { get; set; }
    }
}
