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
            fetchBooks();
        }
        private void fetchBooks() {
            string[] columns = { "Id", "Authors", "Title", "ReleaseDate", "ISBN", "Format", "Pages", "Description" };

            DataTable dt = new DataTable();
            foreach (string column in columns) {
                if (column == "Id" || column == "Pages")
                    dt.Columns.Add(column, typeof(int));
                else
                    dt.Columns.Add(column, typeof(string));
            }

            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM `books`";
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
    }
}