using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            switch(DatabaseSingleton.getInstance().Login(Email.Text, Password.Text))
            {
                case "credfail":
                    DatabaseSingleton.getInstance().Logout();
                    LogWarn.Text = "Your email or password combination was incorrect.";
                    LogWarn.Visible = true;
                    break;
                case "confail":
                    DatabaseSingleton.getInstance().Logout();
                    LogWarn.Text = "Sorry we encountered a problem with the server.";
                    LogWarn.Visible = true;
                    break;
                default:
                    LogWarn.Visible = false;
                    Response.Redirect("../Welcome.aspx");
                    break;

            }
        }
    }
}