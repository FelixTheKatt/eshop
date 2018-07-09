using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models
{
    public class Payement
    {
        public int PayementId { get; set; }
        public string Operation { get; set; }

        public virtual ICollection<Command> Command { get; set; }
        public virtual ModeDePaiment ModeDepaiment { get; set; }
    }
}