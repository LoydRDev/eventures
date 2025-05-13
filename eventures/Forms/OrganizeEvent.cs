using eventures.Forms;
using System;
using System.Windows.Forms;

namespace eventures
{
    public partial class OrganizeEvent : Form
    {
        public OrganizeEvent()
        {
            InitializeComponent();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreateEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var eventDetails = new EventDetails();
            eventDetails.Closed += (s, args) => this.Close();
            eventDetails.Show();
        }
    }
}
