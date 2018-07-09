using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        public string CommandName { get; set; }
        public DateTime CommandDate { get; set; }
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payement Payement { get; set; }
        public virtual ICollection<Product> Product { get; set; }
}
}