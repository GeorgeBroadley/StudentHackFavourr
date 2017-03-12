using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class UserData
    {
        public string fullname;
        public string email;
        public string county;
        public int point;
        public UserData(string fullname,string email, string county, int point)
        {
            this.fullname = fullname;
            this.email = email;
            this.county = county;
            this.point = point;
        }
    }
}