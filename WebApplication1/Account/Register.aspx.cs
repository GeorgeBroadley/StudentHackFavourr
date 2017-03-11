using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(DatabaseSingleton.getInstance().Register(Email.Text, Password.Text, Address.Text, Postcode.Text, Name.Text));
        }
    }
}