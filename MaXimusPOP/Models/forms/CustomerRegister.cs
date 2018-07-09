using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaXimusPOP.Enum;

namespace MaXimusPOP.Models.forms
{
    public class CustomerRegister
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Pwd1 { get; set; }

        [Required]
        [DisplayName("Confirmer")]
        [Compare(nameof(Pwd1))]
        [DataType(DataType.Password)]
        public string Pwd2 { get; set; }

        public CustomerSession RegisterInDB()
        {
            string cryptPwd = Pwd1;
            Customer customer = new Customer()
            {
                Email = this.Email,
                Password = Hash.Hashme(cryptPwd),
                RoleId = (int)RoleEnum.User
            };
            using (Capsule db = new Capsule())
            {
                customer.BirthDate = DateTime.Now;
                customer = db.Customers.Add(customer);
                db.SaveChanges();
                
                if (customer != null)
                {
                    return new CustomerSession()
                    {
                        Mail = customer.Email,
                        UserId = customer.CustomerId,
                        Role = (RoleEnum)customer.RoleId

                    };                    
                }
            }
            return null;
        }
    }
}
