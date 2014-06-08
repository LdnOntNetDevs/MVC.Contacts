using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Contacts.Models
{
    public class ContactPhone
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ContactPhoneId { get; set; }

        [Display(Name = "Phone #")]
        public string PhoneNumber { get; set; }

        public PhoneType Type { get; set; }
        
        [ScaffoldColumn(false)]
        public int ContactId { get; set; }
    }
}