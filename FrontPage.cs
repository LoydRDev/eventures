using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventuree
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bunifuButtonGetStarted_Click(object sender, EventArgs e)
        {
            // Navigate to login form
            LoginPage loginForm = new LoginPage();
            loginForm.Show();

            // Optionally, hide the current form
            this.Hide();
        }
    }
}
