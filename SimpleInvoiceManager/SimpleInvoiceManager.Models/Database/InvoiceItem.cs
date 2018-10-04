using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class InvoiceItem: DatabaseEntity
    {                
        public int InvoiceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float PricePerUnit { get; set; }        
        public float Total { get; set; }
    }
}
