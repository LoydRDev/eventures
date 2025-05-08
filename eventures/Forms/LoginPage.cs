using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventures
{
    public partial class LoginPage: Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registrationform = new Registration();
            registrationform.Closed += (s, args) => this.Close();
            registrationform.Show();
        }
    }
}
