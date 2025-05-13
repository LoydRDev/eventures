using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

using eventures.Models;
using eventures.Validation;

namespace eventures.Forms.CreateEvent
{
    public partial class Participants : Form
    {
        private Event eventData;
        private DateAndLocation dateAndLocationForm;
        private ErrorProvider errorProvider;

        private string GetAgeRestriction(BunifuGroupBox groupBox)
        {
            foreach (var control in groupBox.Controls)
            {
                if (control is BunifuRadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        public Participants(Event eventData, DateAndLocation dateAndLocationForm)
        {
            InitializeComponent();
            eventData = eventData;
            dateAndLocationForm = dateAndLocationForm;
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
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
            dateAndLocationForm.Closed += (s, args) => this.Close();
            dateAndLocationForm.Show();
        }

        private void BtnCreateEvent_Click(object sender, EventArgs e)
        {
            if (EventFormValidation.ValidateParticipants(SlotLimitation, errorProvider))
            {
                eventData.Capacity = int.Parse(SlotLimitation.Text);
                eventData.AgeRestriction = GetAgeRestriction(AgeRestriction);

                //this.Hide();
                //var ConfirmationForm = new Confirmation(eventData, this);
                //ConfirmationForm.Closed += (s, args) => this.Close();
                //ConfirmationForm.Show();
            }
        }
    }
}
