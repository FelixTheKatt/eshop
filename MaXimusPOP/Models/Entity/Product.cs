using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }      
        public string Alias { get; set; }
        public string Statut { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Command> Command { get; set; }
        public virtual ICollection<Categorie> Categorie { get; set; }
        public virtual ICollection<Depot> Depot { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Product)
            {
                if (ProductId.Equals((obj as Product).ProductId))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * ProductId.GetHashCode()) + 7;
            return hash;
        }
    }
}