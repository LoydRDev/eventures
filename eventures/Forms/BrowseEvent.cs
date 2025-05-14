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
