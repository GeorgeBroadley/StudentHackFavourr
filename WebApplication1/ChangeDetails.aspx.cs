using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class ChangeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> details = DatabaseSingleton.getInstance().getUserDetails();
            fullName.Text = details.ElementAt(0);
            address.Text = details.ElementAt(1);
            postcode.Text = details.ElementAt(2);
        }

        protected void ChangeDets_Click(object sender, EventArgs e)
        {
            string Name = fullName.Text;
            string Address = address.Text;
            string Postcode = postcode.Text;
            DatabaseSingleton.getInstance().editDetails(Name, Address, Postcode);
        }
    }
}