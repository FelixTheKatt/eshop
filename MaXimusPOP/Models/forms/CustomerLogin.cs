using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaXimusPOP.Enum;

namespace MaXimusPOP.Models.forms
{
    public class CustomerLogin
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string Mail { get; set; }

        [Required]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        public CustomerSession CheckUser(CustomerLogin cl)
        {
            string cryptPwd = Pwd; 

            using (Capsule db = new Capsule())
            {
                Customer user = db.Customers.Where(x => x.Email == cl.Mail && x.Password == cl.Pwd).FirstOrDefault();
                if (user == null) return null;

                return new CustomerSession()
                {
                    Mail = user.Email,
                    UserId = user.CustomerId,
                    Role = (RoleEnum)user.RoleId
                };
            }
        }
    }
}