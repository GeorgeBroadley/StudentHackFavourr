using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayCurrentUserFavours();
        }

        private void onClick(object sender, EventArgs e)
        {
                string s = (sender as Button).ID;
                DatabaseSingleton.getInstance().DeleteFavour(s);
                Response.Redirect("User.aspx");
        }

        private void displayCurrentUserFavours()
        {

            if (DatabaseSingleton.getInstance().getEmail() != null)
            {
                Table favours = new Table();
                List<string>[] favourslist = DatabaseSingleton.getInstance().CurrentUserFavours();

                for (int i = 0; i < favourslist[0].Count; i++)
                {
                    TableRow fav = new TableRow();

                    TableCell a = new TableCell();
                    a.Text = favourslist[0].ElementAt(i);
                    fav.Cells.Add(a);

                    TableCell b = new TableCell();
                    b.Text = favourslist[1].ElementAt(i);
                    fav.Cells.Add(b);

                    TableCell c = new TableCell();
                    c.Text = favourslist[2].ElementAt(i);
                    fav.Cells.Add(c);

                    TableCell delete = new TableCell();
                    Button btn = new Button();
                    btn.Text = "Delete";
                    btn.ID = favourslist[0].ElementAt(i);
                    btn.Click += new System.EventHandler(onClick);
                    delete.Controls.Add(btn);
                    fav.Cells.Add(delete);

                    favours.Rows.Add(fav);
                }
                userFavours.Controls.Add(favours);
            }
            else
            {
                Response.Redirect("Account/Login");
            }
        }

        protected void ChangeDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeDetails.aspx");
        }
    }

}
 