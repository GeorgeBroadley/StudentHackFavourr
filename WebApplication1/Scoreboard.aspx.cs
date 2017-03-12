using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Scoreboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayData(DatabaseSingleton.getInstance().getUserLeaders());
        }

        private void displayData(List<UserData> userslist)
        {
            Table users = new Table();
            users.CssClass = "table table-striped";

            TableHeaderRow tableHeader = new TableHeaderRow();

            TableHeaderCell rHead = new TableHeaderCell();
            rHead.Style.Add("vertical-align", "middle");
            rHead.Style.Add("text-align", "center");
            rHead.Text = "Rank";
            tableHeader.Cells.Add(rHead);

            TableHeaderCell aHead = new TableHeaderCell();
            aHead.Style.Add("vertical-align", "middle");
            aHead.Style.Add("text-align", "center");
            aHead.Text = "Name";
            tableHeader.Cells.Add(aHead);

            TableHeaderCell bHead = new TableHeaderCell();
            bHead.Style.Add("vertical-align", "middle");
            bHead.Style.Add("text-align", "center");
            bHead.Text = "Email";
            tableHeader.Cells.Add(bHead);

            TableHeaderCell cHead = new TableHeaderCell();
            cHead.Style.Add("vertical-align", "middle");
            cHead.Style.Add("text-align", "center");
            cHead.Text = "Points";
            tableHeader.Cells.Add(cHead);

            TableHeaderCell dHead = new TableHeaderCell();
            dHead.Style.Add("vertical-align", "middle");
            dHead.Style.Add("text-align", "center");
            dHead.Text = "County";
            tableHeader.Cells.Add(dHead);

            users.Rows.Add(tableHeader);

            for (int i = 0; i < userslist.Count; i++)
            {
                TableRow usr = new TableRow();

                TableCell r = new TableCell();
                r.Style.Add("vertical-align", "middle");
                r.Style.Add("text-align", "center");
                r.Text = (i+1).ToString();
                usr.Cells.Add(r);

                TableCell a = new TableCell();
                a.Style.Add("vertical-align", "middle");
                a.Style.Add("text-align", "center");
                a.Text = userslist.ElementAt(i).fullname;
                usr.Cells.Add(a);

                TableCell b = new TableCell();
                b.Style.Add("vertical-align", "middle");
                b.Style.Add("text-align", "center");
                b.Text = userslist.ElementAt(i).email;
                usr.Cells.Add(b);

                TableCell c = new TableCell();
                c.Style.Add("vertical-align", "middle");
                c.Style.Add("text-align", "center");
                c.Text = userslist.ElementAt(i).point.ToString();
                usr.Cells.Add(c);


                TableCell d = new TableCell();
                d.Style.Add("vertical-align", "middle");
                d.Style.Add("text-align", "center");
                d.Text = userslist.ElementAt(i).county;
                usr.Cells.Add(d);


                

                users.Rows.Add(usr);
            }

            usersTable.Controls.Add(users);
        }
    }
}