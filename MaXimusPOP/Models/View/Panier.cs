using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models.View
{
    public class Panier
    {
        #region prop
        public Dictionary<Product, int> Contenu { get; set; }

        #endregion

        public int Total()
        {
            int PrixTot = 0;

            foreach (var item in Contenu)
            {
                int prixUnitaire = item.Key.Price;
                PrixTot += (prixUnitaire * item.Value);
            }

            return PrixTot;
        }
        
    }
}