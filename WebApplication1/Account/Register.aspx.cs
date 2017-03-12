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
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            switch(DatabaseSingleton.getInstance().Register(Email.Text, Password.Text, Address.Text, Postcode.Text, Name.Text, County.Text)){
                case "success":
                    EmailWarn.Visible = false;
                    Response.Redirect("../Welcome.aspx");
                    break;
                case "existingemail":
                    EmailWarn.Text = "That email is already in use";
                    EmailWarn.Visible = true;
                    break;
                default:
                    EmailWarn.Text = "Sorry we encountered a problem with our servers";
                    EmailWarn.Visible = true;
                    break;
            }

        }
    }
}