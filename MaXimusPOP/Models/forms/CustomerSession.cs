using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaXimusPOP.Enum;

namespace MaXimusPOP.Models.forms
{
    public class CustomerSession
    {
        public int UserId { get; set; }
        public string Mail { get; set; }
        public RoleEnum Role { get; set; }
        public List<Product> CurrentProduct { get; set; }

        public CustomerSession()
        {
            CurrentProduct = new List<Product>();
        }
    }
}