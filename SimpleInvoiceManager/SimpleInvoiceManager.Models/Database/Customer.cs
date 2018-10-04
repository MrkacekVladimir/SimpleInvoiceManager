using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class Customer: DatabaseEntity
    {
        [Required]
        public string Name { get; set; }        
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"[1-9]{1}[0-9]{2} [0-9]{2}$",ErrorMessage = "Type ZIP Code in correct format.(Eg. 123 45)")]
        public string ZipCode { get; set; }
        [Required]
        [Phone]        
        public string PhoneNumber { get; set; }
    }
}
