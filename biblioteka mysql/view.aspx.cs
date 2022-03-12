using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace biblioteka_mysql
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["conn"] == null) {
                Response.Redirect("connect.aspx");
            }
            else if (Session["log"] == null) {
                Response.Redirect("login.aspx");
            }
            fetchBooks();
        }
        private void fetchBooks() {
            string[] columns = { "Id", "Authors", "Title", "ReleaseDate", "ISBN", "Format", "Pages", "Description" };

            DataTable dt = new DataTable();
            foreach (string column in columns.Reverse()) {
                if (column == "Id" || column == "Pages")
                    dt.Columns.Add(column, typeof(int));
                else
                    dt.Columns.Add(column, typeof(string));
            }

            string filters = "";
            foreach (string column in columns) {
                string filter = Session["search" + column] as string;
                if (filter != "") {
                    if (filters == "") {
                        filters = $" WHERE `{column}` LIKE '%{filter}%'";
                    }
                    else {
                        filters += $" OR `{column}` LIKE '%{filter}%'";
                    }
                }
            }

            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM `books`" + filters;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                DataRow row = dt.NewRow();
                foreach (string column in columns) {
                    if (column == "Id" || column == "Pages")
                        row[column] = reader.GetInt32(column);
                    else
                        row[column] = reader.GetString(column);
                }
                dt.Rows.Add(row);
            }
            reader.Close();
            books.DataSource = dt;
            books.DataBind();
        }

        protected void bAddBook_Click(object sender, EventArgs e) {
            Response.Redirect("add.aspx");
        }

        protected void books_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow clickedRow = books.Rows[index];
            String id = clickedRow.Cells[9].Text;
            if (e.CommandName == "bookEdit") {
                Response.Redirect("edit.aspx?id=" + id);
            }
            else if (e.CommandName == "bookDelete") {
                MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
                command.CommandText = $"DELETE FROM `books` WHERE `Id` = {id};";
                System.Diagnostics.Debug.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void bSearchBooks_Click(object sender, EventArgs e) {
            Response.Redirect("search.aspx");
        }

        protected void bClearFilters_Click(object sender, EventArgs e) {
            string[] columns = { "Id", "Authors", "Title", "ReleaseDate", "ISBN", "Format", "Pages", "Description" };
            foreach (string column in columns) {
                Session["search" + column] = "";
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}