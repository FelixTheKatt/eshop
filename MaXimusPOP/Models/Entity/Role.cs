using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        
    }
}