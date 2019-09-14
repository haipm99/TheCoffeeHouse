using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoffeehouse.Data.Models.View
{
    public class AppUserModelView
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
    }

    public class AppUserRegisterView
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string confirm { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }

    public class AppUserLoginView
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
