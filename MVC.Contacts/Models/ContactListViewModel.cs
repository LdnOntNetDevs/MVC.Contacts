using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Contacts.Models
{
    public class ContactListViewModel
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
    }
}