using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Depot
    {
        public int DepotID { get; set; }
        public int Quantite { get; set; }
        public string lieu { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}