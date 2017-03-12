using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Gift : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Click(object sender, EventArgs e)
        {
            string curEmail = DatabaseSingleton.getInstance().getEmail();
            string name = favourname.Text;
            if(curEmail == null)
            {
                WarnLog.Visible = true;
                WarnLog.Text = "You need to log in to create a favour";
            }
            else if (DatabaseSingleton.getInstance().favourExists(curEmail, name))
            {
                WarnLog.Visible = true;
                WarnLog.Text = "This favour already exists";
            }
            else
            {
                WarnLog.Visible = false;
                string desc = Descr.Text;
                string cat = Category.Text;
                System.Diagnostics.Debug.WriteLine(DatabaseSingleton.getInstance().CreateFavour(curEmail, name, 0, cat, desc, null));
                favourname.Text = "";
                Descr.Text = "";
            }
        }
    }
 }