using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}