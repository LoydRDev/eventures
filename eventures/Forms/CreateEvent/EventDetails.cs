using System;
using System.Windows.Forms;

using eventures.Forms.CreateEvent;
using eventures.Models;
using eventures.Validation;

namespace eventures.Forms
{
    public partial class EventDetails: Form
    {
        public Event eventData { get; set; } = new Event();
        private ErrorProvider errorProvider;

        public EventDetails()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (EventFormValidation.ValidateEventDetails(TBEventName, TBDescription, DdCategory, errorProvider))
            {
                eventData.EventName = TBEventName.Text;
                eventData.Description = TBDescription.Text;
                eventData.Category = DdCategory.SelectedItem.ToString();

                this.Hide();
                var dateAndLocationForm = new DateAndLocation(eventData, this);
                dateAndLocationForm.Closed += (s, args) => this.Close();
                dateAndLocationForm.Show();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var organizeEventForm = new OrganizeEvent();
            organizeEventForm.Closed += (s, args) => this.Close();
            organizeEventForm.Show();
        }
    }
}
