using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Models.DomainModels
{
    public class AspNetUserRole
    {
        //public int ID { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole AspNetRole { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
