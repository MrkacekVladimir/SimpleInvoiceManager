using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleInvoiceManager.Models.Database
{
    public class Customer : DatabaseEntity
    {
        [Required]
        [DisplayName("Company name")]
        public string Name { get; set; }        
        [Required]
        [DisplayName("Street address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DisplayName("Zip Code")]
        [RegularExpression(@"[1-9]{1}[0-9]{2} [0-9]{2}$",ErrorMessage = "Type ZIP Code in correct format.(Eg. 123 45)")]
        public string ZipCode { get; set; }
        [Required]
        [Phone]        
        public string PhoneNumber { get; set; }
    }
}
