using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayFavours();
            displayData(favourslist);
        }

        private void onClick(object sender, EventArgs e)
        {
            if (DatabaseSingleton.getInstance().getEmail() != null)
            {
                LogWarn.Visible = false;
                string s = (sender as Button).ID;
                int comma = s.IndexOf(",");
                DatabaseSingleton.getInstance().claimFavour(s.Substring(comma + 1), s.Substring(0, comma),true);
                Response.Redirect("Default.aspx");
            }else
            {
                LogWarn.Visible = true;
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string>[] favourslist;
            if (County.Text == "All")
            {
               favourslist = DatabaseSingleton.getInstance().DisplayFavours();
            }
            else
            {
                 favourslist = DatabaseSingleton.getInstance().DisplayCountyFavours(County.Text);
            }
            
            displayData(favourslist);
        }

        protected void accounting_Click(object sender, ImageClickEventArgs e)
        {

            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayCatFavours(County.Text, "Accounting");
            displayData(favourslist);
        }

        protected void tech_Click(object sender, ImageClickEventArgs e)
        {
            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayCatFavours(County.Text, "Technical Help");
            displayData(favourslist);
        }

        protected void garden_Click(object sender, ImageClickEventArgs e)
        {
            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayCatFavours(County.Text, "Gardening");
            displayData(favourslist);
        }

        protected void decor_Click(object sender, ImageClickEventArgs e)
        {
            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayCatFavours(County.Text, "Decorating");
            displayData(favourslist);
        }

        protected void mech_Click(object sender, ImageClickEventArgs e)
        {
            List<string>[] favourslist = DatabaseSingleton.getInstance().DisplayCatFavours(County.Text, "Mechanical");
            displayData(favourslist);
        }

        private void displayData(List<string>[] favourslist)
        {
            Table favours = new Table();
            favoursTable.Controls.Clear();
            favours.CssClass = "table table-striped";
            
            TableHeaderRow tableHeader = new TableHeaderRow();

            TableHeaderCell aHead = new TableHeaderCell();
            aHead.Style.Add("vertical-align", "middle");
            aHead.Style.Add("text-align", "center");
            aHead.Text = "Name";
            tableHeader.Cells.Add(aHead);

            TableHeaderCell bHead = new TableHeaderCell();
            bHead.Style.Add("vertical-align", "middle");
            bHead.Style.Add("text-align", "center");
            bHead.Text = "Description";
            tableHeader.Cells.Add(bHead);

            TableHeaderCell cHead = new TableHeaderCell();
            cHead.Style.Add("vertical-align", "middle");
            cHead.Style.Add("text-align", "center");
            cHead.Text = "Category";
            tableHeader.Cells.Add(cHead);

            TableHeaderCell dHead = new TableHeaderCell();
            dHead.Style.Add("vertical-align", "middle");
            dHead.Style.Add("text-align", "center");
            dHead.Text = "Email";
            tableHeader.Cells.Add(dHead);

            TableHeaderCell eHead = new TableHeaderCell();
            eHead.Style.Add("vertical-align", "middle");
            eHead.Style.Add("text-align", "center");
            eHead.Text = "Options";
            tableHeader.Cells.Add(eHead);

            favours.Rows.Add(tableHeader);

            if (favourslist[0].Count == 0)
            {
                TableRow defaultRow = new TableRow();

                TableCell a = new TableCell();
                a.Style.Add("vertical-align", "middle");
                a.Style.Add("text-align", "center");
                a.Text = "Sorry, there is nothing here.";
                a.ColumnSpan = 5;
                defaultRow.Cells.Add(a);

                favours.Rows.Add(defaultRow);
            }
            else
            {
                for (int i = 0; i < favourslist[0].Count; i++)
                {
                    TableRow fav = new TableRow();

                    TableCell a = new TableCell();
                    a.Style.Add("vertical-align", "middle");
                    a.Style.Add("text-align", "center");
                    a.Text = favourslist[0].ElementAt(i);
                    fav.Cells.Add(a);
                
                    TableCell b = new TableCell();
                    b.Style.Add("vertical-align", "middle");
                    b.Style.Add("text-align", "center");
                    b.Text = favourslist[1].ElementAt(i);
                    fav.Cells.Add(b);

                    TableCell c = new TableCell();
                    c.Style.Add("vertical-align", "middle");
                    c.Style.Add("text-align", "center");
                    c.Text = favourslist[2].ElementAt(i);
                    fav.Cells.Add(c);


                    TableCell d = new TableCell();
                    d.Style.Add("vertical-align", "middle");
                    d.Style.Add("text-align", "center");
                    d.Text = favourslist[3].ElementAt(i);
                    fav.Cells.Add(d);


                    TableCell claim = new TableCell();
                    claim.Style.Add("text-align", "center");
                    Button btn = new Button();
                    btn.CssClass = "btn btn-default";
                    //btn.OnClientClick = DatabaseSingleton.getInstance().claimFavour(favourslist[3].ElementAt(i), favourslist[0].ElementAt(i)); 
                    btn.Text = "Claim Favour";
                    btn.ID = favourslist[0].ElementAt(i) + "," + favourslist[3].ElementAt(i);
                    btn.Click += new System.EventHandler(onClick);
                    claim.Controls.Add(btn);
                    fav.Cells.Add(claim);

                    favours.Rows.Add(fav);
                }
            }

            //for (int i = 0; i < favourslist.Length; i++)
            //{
            //    foreach (var item in favourslist[i])
            //    {
            //        TableRow fav = new TableRow();
            //        TableCell tc = new TableCell();
            //        tc.Text = item;
            //        fav.Cells.Add(tc);
            //        favours.Rows.Add(fav);
            //    }
            //}

            favoursTable.Controls.Add(favours);
        }
    }
}