using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public string Pays { get; set; }
        public string Province { get; set; }
        public int NumeroRue { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public bool Active { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Command> Command { get; set; }

}
}