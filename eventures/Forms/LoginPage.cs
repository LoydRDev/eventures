using System;
using System.Windows.Forms;

using eventures.DataAccess;
using eventures.Models;

namespace eventures
{
    public partial class LoginPage: Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registrationform = new Registration();
            registrationform.Closed += (s, args) => this.Close();
            registrationform.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TBLoginUsername.Text;
            string password = TBLoginPassword.Text;

            UserDAO userDAO = new UserDAO();
            User loggedInUser = userDAO.AuthenticateUser(username, password);

            if (loggedInUser != null)
            {
                MessageBox.Show($"Welcome, {loggedInUser.FirstName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var dashboard = new Dashboard(username);
                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Show();
            }
            else 
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
