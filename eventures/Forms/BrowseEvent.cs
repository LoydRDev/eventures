using eventures.Forms;
using System;
using System.Windows.Forms;

namespace eventures
{
    public partial class BrowseEvent: Form
    {
        public BrowseEvent()
        {
            InitializeComponent();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void BtnOrganizeEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var organizeEvent = new OrganizeEvent();
            organizeEvent.Closed += (s, args) => this.Close();
            organizeEvent.Show();
        }

        private void BtnEventHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var eventHistory = new EventHistory();
            eventHistory.Closed += (s, args) => this.Close();
            eventHistory.Show();
        }
    }
}
