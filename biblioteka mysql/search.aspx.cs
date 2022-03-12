using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace biblioteka_mysql
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["conn"] == null) {
                Response.Redirect("connect.aspx");
            }
            else if (Session["log"] == null) {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack) {
                setCurrentValues();
            }
        }
        private void setCurrentValues() {
            iId.Text = Session["searchId"] as string;
            iAuthors.Text = Session["searchAuthors"] as string;
            iTitle.Text = Session["searchTitle"] as string;
            iReleaseDate.Text = Session["searchReleaseDate"] as string;
            iISBN.Text = Session["searchISBN"] as string;
            iFormat.Text = Session["searchFormat"] as string;
            iPages.Text = Session["searchPages"] as string;
            iDescription.Text = Session["searchDescription"] as string;
        }
        protected void bSearch_Click1(object sender, EventArgs e) {
            Session["searchId"] = iId.Text;
            Session["searchAuthors"] = iAuthors.Text;
            Session["searchTitle"] = iTitle.Text;
            Session["searchReleaseDate"] = iReleaseDate.Text;
            Session["searchISBN"] = iISBN.Text;
            Session["searchFormat"] = iFormat.Text;
            Session["searchPages"] = iPages.Text;
            Session["searchDescription"] = iDescription.Text;

            Response.Redirect("view.aspx");
        }
    }
}