using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class PhoneBook
    {
        public int PhoneBookId { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual GroupName GroupName { get; set; }
        public System.DateTime DateEntry { get; set; }
    }
}