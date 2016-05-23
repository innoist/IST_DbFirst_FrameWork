using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IST.Web.Models
{
    public class SystemUser
    {
        public string KeyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
    }
}