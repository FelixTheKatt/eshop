using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaXimusPOP.Models.View
{
    public class Page<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int? Previous
        {
            get
            {
                return PageNumber > 0 ? (int?)PageNumber - 1 : null;
            }
        }
        public int PageNumber { get; set; }

        public int? Next
        {
            get
            {
                return PageNumber < Total / Limit ? (int?)PageNumber + 1 : null;
            }
        }
        public int Limit { get; set; }
        public int Count
        {
            get
            {
                return Items.Count();
            }
        }
        public int Total { get; set; }
    }
}