using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace biblioteka_mysql
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool addBook(string authors, string title, string releaseDate, string isbn,
            string format, int pages, string description) {
            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            System.Diagnostics.Debug.WriteLine(authors, title, releaseDate, isbn, format, pages, description);
            try {
                command.CommandText = "INSERT INTO `books`(`Authors`, `Title`, `ReleaseDate`, `ISBN`, `Format`, `Pages`, `Description`) " +
                    $"VALUES('{authors}', '{title}', '{releaseDate}', '{isbn}', '{format}', {pages}, '{description}')";
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
        protected void bAdd_Click1(object sender, EventArgs e) {
            int pages;
            try {
                pages = int.Parse(iPages.Text);
            }
            catch (FormatException) {
                pages = 0;
            }
            bool result = addBook(
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