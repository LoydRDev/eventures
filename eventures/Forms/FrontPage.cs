using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace eventures
{
    public partial class FrontPage : Form
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void bunifuButtonGetStarted_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginPage();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
