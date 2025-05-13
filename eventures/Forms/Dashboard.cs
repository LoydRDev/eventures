using eventures.Forms;
using System;
using System.Windows.Forms;

namespace eventures
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnBrowseEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var browseEventForm = new BrowseEvent();
            browseEventForm.Closed += (s, args) => this.Close();
            browseEventForm.Show();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dashboardForm = new Dashboard();
            dashboardForm.Closed += (s, args) => this.Close();
            dashboardForm.Show();
        }

        private void BtnOrganizeEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var organizeEventForm = new OrganizeEvent();
            organizeEventForm.Closed += (s, args) => this.Close();
            organizeEventForm.Show();
        }

        private void BtnEventHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var eventHistoryForm = new EventHistory();
            eventHistoryForm.Closed += (s, args) => this.Close();
            eventHistoryForm.Show();
        }

    }
}
