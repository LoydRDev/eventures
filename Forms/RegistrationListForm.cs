using System;
using System.Windows.Forms;
using System.Collections.Generic;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{
    public partial class RegistrationsListForm : Form
    {
        private Event currentEvent;
        private List<Registration> registrations;

        public RegistrationsListForm(Event evt)
        {
            InitializeComponent();
            currentEvent = evt;
            LoadEventDetails();
            LoadRegistrations();
        }

        private void LoadEventDetails()
        {
            lblEventDetails.Text = $"Event: {currentEvent.EventName}\nDate: {currentEvent.EventDate:g}\nLocation: {currentEvent.Location}";

            int registrationCount = RegistrationDAO.GetEventRegistrationCount(currentEvent.EventId);
            lblRegistrationCount.Text = $"Total Registrations: {registrationCount} of {currentEvent.MaxAttendees}";
        }

        private void LoadRegistrations()
        {
            try
            {
                registrations = RegistrationDAO.GetEventRegistrations(currentEvent.EventId);
                var registrationData = new List<dynamic>();

                foreach (var registration in registrations)
                {
                    var attendee = AttendeeDAO.GetAttendeeById(registration.AttendeeId);
                    registrationData.Add(new
                    {
                        RegistrationId = registration.RegistrationId,
                        AttendeeId = registration.AttendeeId,
                        AttendeeName = $"{attendee.FirstName} {attendee.LastName}",
                        Email = attendee.Email,
                        RegistrationDate = registration.RegistrationDate,
                        Status = registration.Status,
                        AttendanceStatus = registration.AttendanceStatus,
                        HasAttended = registration.HasAttended
                    });
                }

                dgvRegistrations.DataSource = registrationData;
                FormatDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading registrations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGrid()
        {
            dgvRegistrations.Columns["RegistrationId"].Visible = false;
            dgvRegistrations.Columns["AttendeeId"].Visible = false;
            dgvRegistrations.Columns["AttendeeName"].HeaderText = "Attendee Name";
            dgvRegistrations.Columns["Email"].HeaderText = "Email";
            dgvRegistrations.Columns["RegistrationDate"].HeaderText = "Registration Date";
            dgvRegistrations.Columns["Status"].HeaderText = "Status";
            dgvRegistrations.Columns["AttendanceStatus"].HeaderText = "Attendance Status";
            dgvRegistrations.Columns["HasAttended"].HeaderText = "Has Attended";

            foreach (DataGridViewColumn column in dgvRegistrations.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRegistrations.SelectedRows[0];
                int registrationId = (int)selectedRow.Cells["RegistrationId"].Value;
                var registration = registrations.Find(r => r.RegistrationId == registrationId);

                if (registration != null)
                {
                    using (var statusForm = new RegistrationStatusForm(registration))
                    {
                        if (statusForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadRegistrations();
                        }
                    }
                }
            }
        }

        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRegistrations.SelectedRows[0];
                int attendeeId = (int)selectedRow.Cells["AttendeeId"].Value;

                var notification = new Notification
                {
                    EventId = currentEvent.EventId,
                    AttendeeId = attendeeId,
                    NotificationType = "Reminder",
                    Message = $"Reminder: You are registered for {currentEvent.EventName} on {currentEvent.EventDate:g}",
                    CreatedDate = DateTime.Now,
                    Status = "Pending",
                    DeliveryMethod = "Email"
                };

                try
                {
                    NotificationDAO.CreateNotification(notification);
                    MessageBox.Show("Notification has been queued for sending.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending notification: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRegistrations();
        }
    }
}