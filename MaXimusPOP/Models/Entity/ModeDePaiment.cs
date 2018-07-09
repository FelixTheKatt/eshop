using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class ModeDePaiment
    {
        public int ModeDePaimentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Payement> Payement { get; set; }
    }
}