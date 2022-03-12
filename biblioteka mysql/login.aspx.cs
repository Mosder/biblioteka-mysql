using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace biblioteka_mysql
{
    public class User {
        public string email;
        public string login;
        public string password;

        public User(string e, string l, string p) {
            email = e;
            login = l;
            password = p;
        }
    }
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["conn"] == null) {
                Response.Redirect("connect.aspx");
            }
            else if (Session["log"] != null) {
                Response.Redirect("view.aspx");
            }
            if (Request.QueryString["register"] != null) {
                lHeader.Text = "Register";
                lEmail.Visible = true;
                iEmail.Visible = true;
                bLogin.Text = "Register and login";
                bChange.Text = "Login instead";
            }
        }
        private List<User> fetchUsers() {
            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            command.CommandText = "SELECT * FROM `users`";
            MySqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read()) {
                users.Add(new User(reader.GetString("Email"), reader.GetString("Login"), reader.GetString("Password")));
            }
            reader.Close();
            return users;
        }

        protected void bChange_Click(object sender, EventArgs e) {
            if (Request.QueryString["register"] == null) {
                Response.Redirect("login.aspx?register=1");
            }
            else {
                Response.Redirect("login.aspx");
            }
        }

        protected void bLogin_Click(object sender, EventArgs e) {
            List<User> users = fetchUsers();
            bool gut = false;
            if (Request.QueryString["register"] != null) {
                if (iEmail.Text == "" || iLogin.Text == "" || iPassword.Text == "") {
                    lInfo.Text = "Email, login and password cannot be empty";
                    lInfo.Visible = true;
                    return;
                }
                foreach (User user in users) {
                    if (user.email == iEmail.Text) {
                        lInfo.Text = "This email is already in use";
                        lInfo.Visible = true;
                        return;
                    }
                    else if (user.login == iLogin.Text) {
                        lInfo.Text = "This login is already in use";
                        lInfo.Visible = true;
                        return;
                    }
                }
                gut = addUser(iEmail.Text, iLogin.Text, iPassword.Text);
            }
            else {
                foreach (User user in users) {
                    if (user.login == iLogin.Text && user.password == FormsAuthentication.HashPasswordForStoringInConfigFile(iPassword.Text, "MD5")) {
                        Session["log"] = 1;
                        Response.Redirect("view.aspx");
                    }
                }
                lInfo.Text = "Wrong login or password";
                lInfo.Visible = true;
                return;
            }
            if (gut) {
                Session["log"] = 1;
                Response.Redirect("view.aspx");
            }
            else {
                lInfo.Text = "Something went wrong...";
            }
        }
        private bool addUser(string email, string login, string password) {
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            MySqlCommand command = (Session["conn"] as MySqlConnection).CreateCommand();
            try {
                command.CommandText = "INSERT INTO `users`(`Login`, `Password`, `Email`) " +
                    $"VALUES('{login}', '{password}', '{email}')";
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
    }
}