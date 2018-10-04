using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleInvoiceManager.Models.Database
{
    public class Invoice: DatabaseEntity
    {
        [Required]        
        [DisplayName("Invoice number")]
        public int InvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Invoice date")]
        public DateTime InvoiceDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Payment due date")]
        public DateTime PaymentDueDate { get; set; }
        [Required]        
        public int Tax { get; set; }
        [Required]
        [DisplayName("Paid")]
        public bool PaymentStatus { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }
        public virtual Customer Customer { get; set; }        
    }
}
