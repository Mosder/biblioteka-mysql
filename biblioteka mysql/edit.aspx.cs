using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace biblioteka_mysql
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["conn"] == null) {
                Response.Redirect("connect.aspx");
            }
            else if (Session["log"] == null) {
                Response.Redirect("login.aspx");
            }
            else if (Request.QueryString["Id"] == null) {
                Response.Redirect("view.aspx");
            }
            int id = int.Parse(Request.QueryString["Id"]);
            if (!IsPostBack) {
                setCurrentValues(id);
            }
        }
        private void setCurrentValues(int id) {
            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM `books` WHERE `Id` = " + id;
            MySqlDataReader reader = command.ExecuteReader();
            bool goodBook = false;
            while (reader.Read()) {
                goodBook = true;
                lIdVal.Text = Convert.ToString(reader.GetInt32("Id"));
                iAuthors.Text = reader.GetString("Authors");
                iTitle.Text = reader.GetString("Title");
                iReleaseDate.Text = reader.GetString("ReleaseDate");
                iISBN.Text = reader.GetString("ISBN");
                iFormat.Text = reader.GetString("Format");
                iPages.Text = Convert.ToString(reader.GetInt32("Pages"));
                iDescription.Text = reader.GetString("Description");
            }
            reader.Close();
            if (!goodBook) {
                Response.Redirect("view.aspx");
            }
        }
        private bool editBook(int id, string authors, string title, string releaseDate, string isbn,
            string format, int pages, string description) {
            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            try {
                command.CommandText = $"UPDATE `books` SET `Authors` = '{authors}', `Title` = '{title}', `ReleaseDate` = '{releaseDate}', " +
                    $"`ISBN` = '{isbn}', `Format` = '{format}', `Pages` = {pages}, `Description` = '{description}' WHERE `Id` = {id}";
                System.Diagnostics.Debug.Write(command.CommandText);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Error:");
                System.Diagnostics.Debug.Write(ex);
                return false;
            }
        }
        protected void bEdit_Click1(object sender, EventArgs e) {
            int pages;
            try {
                pages = int.Parse(iPages.Text);
            }
            catch (FormatException) {
                pages = 0;
            }
            bool result = editBook(
                int.Parse(lIdVal.Text),
                iAuthors.Text,
                iTitle.Text,
                iReleaseDate.Text,
                iISBN.Text,
                iFormat.Text,
                pages,
                iDescription.Text
            );
            if (result) {
                Response.Redirect("view.aspx");
            }
        }
    }
}