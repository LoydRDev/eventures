using System;
using System.Windows.Forms;

using eventures.Models;
using eventures.Validation;

namespace eventures.Forms.CreateEvent
{
    public partial class DateAndLocation : Form
    {
        private ErrorProvider errorProvider;
        private Event eventData;
        private EventDetails eventDetailsForm;

        public DateAndLocation(Event eventData, EventDetails eventDetailsForm)
        {
            InitializeComponent();
            eventData = eventData;
            eventDetailsForm = eventDetailsForm;
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (EventFormValidation.ValidateDateAndLocation(DPEventDate,DPEventStart, DPEventEnd, TBEventLocation, errorProvider))
            {
                eventData.EventDate = DPEventDate.Value;
                eventData.EventStart = DPEventStart.Value;
                eventData.EventDate = DPEventEnd.Value;
                eventData.Location = TBEventLocation.Text;

                this.Hide();
                var participantsForm = new Participants(eventData, this);
                participantsForm.Closed += (s, args) => this.Close();
                participantsForm.Show();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var organizeEventForm = new OrganizeEvent();
                organizeEventForm.Closed += (s, args) => this.Close();
                organizeEventForm.Show();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            eventDetailsForm.Closed += (s, args) => this.Close();
            eventDetailsForm.Show();
        }
    }
}
