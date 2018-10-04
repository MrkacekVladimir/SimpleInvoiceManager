using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class Invoice: DatabaseEntity
    {       
        [Required]        
        public int InvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public DateTime PaymentDueDate { get; set; }
        [Required]        
        public int Tax { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }
        public virtual Customer Customer { get; set; }        
    }
}
