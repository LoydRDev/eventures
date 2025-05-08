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
    public partial class Registration: Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginPage();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
