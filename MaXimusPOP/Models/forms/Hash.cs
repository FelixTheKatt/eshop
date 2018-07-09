using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MaXimusPOP.Models.forms
{
    public static class Hash
    {
        public static string Hashme(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] byteArray = Encoding.UTF8.GetBytes(password);
            byte[] result = sha256.ComputeHash(byteArray);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}