using System;
using System.Windows.Forms;
using System.Collections.Generic;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{
    public partial class RegistrationForm : Form
    {
        private Event currentEvent;
        private List<Attendee> attendees;

        public RegistrationForm(Event evt)
        {
            InitializeComponent();
            currentEvent = evt;
            LoadEventDetails();
            LoadAttendees();
        }

        private void LoadEventDetails()
        {
            lblEventDetails.Text = $"Event: {currentEvent.EventName}\nDate: {currentEvent.EventDate:g}\nLocation: {currentEvent.Location}";

            int registrationCount = RegistrationDAO.GetEventRegistrationCount(currentEvent.EventId);
            int remainingSpots = currentEvent.MaxAttendees - registrationCount;
            lblAvailability.Text = $"Available Spots: {remainingSpots} of {currentEvent.MaxAttendees}";

            if (remainingSpots <= 0)
            {
                MessageBox.Show("This event is fully booked.", "Registration Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRegister.Enabled = false;
            }
        }

        private void LoadAttendees()
        {
            attendees = AttendeeDAO.GetAllAttendees();
            cboAttendee.DataSource = attendees;
            cboAttendee.DisplayMember = "LastName";
            cboAttendee.ValueMember = "AttendeeId";
        }

        private void btnNewAttendee_Click(object sender, EventArgs e)
        {
            using (var attendeeForm = new AttendeeForm())
            {
                if (attendeeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAttendees();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboAttendee.SelectedItem == null)
            {
                MessageBox.Show("Please select an attendee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedAttendee = (Attendee)cboAttendee.SelectedItem;
                var registration = new Registration
                {
                    EventId = currentEvent.EventId,
                    AttendeeId = selectedAttendee.AttendeeId,
                    RegistrationDate = DateTime.Now,
                    Status = "Confirmed",
                    AttendanceStatus = "Registered",
                    Notes = txtNotes.Text,
                    HasAttended = false
                };

                RegistrationDAO.CreateRegistration(registration);

                // Create notification for the registration
                var notification = new Notification
                {
                    EventId = currentEvent.EventId,
                    AttendeeId = selectedAttendee.AttendeeId,
                    NotificationType = "Registration Confirmation",
                    Message = $"You have been registered for {currentEvent.EventName} on {currentEvent.EventDate:g}",
                    CreatedDate = DateTime.Now,
                    Status = "Pending",
                    DeliveryMethod = "Email"
                };

                NotificationDAO.CreateNotification(notification);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering attendee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}