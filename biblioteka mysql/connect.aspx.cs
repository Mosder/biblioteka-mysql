using System;
using MySqlConnector;

namespace biblioteka_mysql
{
    public partial class connect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bConnect_Click(object sender, EventArgs e) {
            Session["conn"] = conn();
            string[] columns = { "Id", "Authors", "Title", "ReleaseDate", "ISBN", "Format", "Pages", "Description" };
            foreach (string column in columns) {
                Session["search" + column] = "";
            }
            if (Session["conn"] != null)
                Response.Redirect("login.aspx");
        }

        private MySqlConnection conn() {
            string myconnection =
                "Server=" + iServer.Text + ";" +
                "Port=" + iPort.Text + ";" +
                "Database=" + iDatabase.Text + ";" +
                "User=" + iUser.Text + ";" +
                "Password=" + iPassword.Text + ";";
            MySqlConnection connection = new MySqlConnection(myconnection);
            try {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected");
                return connection;
            }
            catch {
                System.Diagnostics.Debug.WriteLine("Error");
                lInfo.Visible = true;
            }
            return null;
        }
    }
}