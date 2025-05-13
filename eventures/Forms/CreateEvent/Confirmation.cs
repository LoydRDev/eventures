using System;
using System.Windows.Forms;

using eventures.Models;
using eventures.DataAccess;

namespace eventures.Forms.CreateEvent
{
    public partial class Confirmation: Form
    {
        private Event eventData;
        private Participants participantsForm;
        private EventDAO eventDAO = new EventDAO();
        public Confirmation(Event eventData,Participants participantsForm)
        {
            InitializeComponent();
            this.eventData = eventData;
            this.participantsForm = participantsForm;
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            EventName.Text = eventData.EventName;
            EventCategory.Text = eventData.Category;
            EventDate.Text = eventData.EventDate.ToString("dd/MM/yyyy");
            EventTimeStart.Text = eventData.EventStart.ToString("HH:mm");
            EventTimeEnd.Text = eventData.EventEnd.ToString("HH:mm");
            EventLocation.Text = eventData.Location;
            AgeRestriction.Text = eventData.AgeRestriction;
            EventCapacity.Text = eventData.Capacity.ToString();
        }

        private void BtnCreateEvent_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to create this event?", "Create Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                eventDAO.CreateEvent(eventData);
                MessageBox.Show("Event created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var organizeEventForm = new OrganizeEvent();
                organizeEventForm.Closed += (s, args) => this.Close();
                organizeEventForm.Show();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var organizeEventForm = new OrganizeEvent();
            organizeEventForm.Closed += (s, args) => this.Close();
            organizeEventForm.Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            participantsForm.Closed += (s, args) => this.Close();
            participantsForm.Show();
        }
    }
}
