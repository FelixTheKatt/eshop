using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaXimusPOP.Models.forms;

namespace MaXimusPOP.Tools
{
    public class SessionManager
    {
        private const string LOGGED_KEY = "LoggedUser";

        private static SessionManager _Instance;

        public static SessionManager Instance
        {
            get { return _Instance ?? (_Instance = new SessionManager()); }
        }

        public CustomerSession LoggedUser
        {
            get { return (CustomerSession)HttpContext.Current.Session[LOGGED_KEY] ?? new CustomerSession(); }
            set { HttpContext.Current.Session[LOGGED_KEY] = value; }
        }

        public bool IsAuthenticated
        {
            get { return LoggedUser.UserId > 0; }
        }
    }
}