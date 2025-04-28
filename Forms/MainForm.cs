using System;
using System.Windows.Forms;
using System.Collections.Generic;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{
    public partial class MainForm : Form
    {
        private List<Event> events;
        private List<Attendee> attendees;

        public MainForm()
        {
            InitializeComponent();
            LoadEvents();
            LoadAttendees();
        }

        private void LoadEvents()
        {
            try
            {
                events = EventDAO.GetAllEvents();
                dgvEvents.DataSource = events;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendees()
        {
            try
            {
                attendees = AttendeeDAO.GetAllAttendees();
                dgvAttendees.DataSource = attendees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            using (var eventForm = new EventForm())
            {
                if (eventForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEvents();
                }
            }
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 0)
            {
                var selectedEvent = (Event)dgvEvents.SelectedRows[0].DataBoundItem;
                using (var eventForm = new EventForm(selectedEvent))
                {
                    if (eventForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEvents();
                    }
                }
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 0)
            {
                var selectedEvent = (Event)dgvEvents.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Are you sure you want to delete event '{selectedEvent.EventName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        EventDAO.DeleteEvent(selectedEvent.EventId);
                        LoadEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 0)
            {
                var selectedEvent = (Event)dgvEvents.SelectedRows[0].DataBoundItem;
                using (var registrationForm = new RegistrationForm(selectedEvent))
                {
                    if (registrationForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEvents();
                        LoadAttendees();
                    }
                }
            }
        }

        private void btnViewRegistrations_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 0)
            {
                var selectedEvent = (Event)dgvEvents.SelectedRows[0].DataBoundItem;
                using (var registrationsForm = new RegistrationsListForm(selectedEvent))
                {
                    registrationsForm.ShowDialog();
                }
            }
        }

        private void btnManageNotifications_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 0)
            {
                var selectedEvent = (Event)dgvEvents.SelectedRows[0].DataBoundItem;
                using (var notificationsForm = new NotificationsForm(selectedEvent))
                {
                    notificationsForm.ShowDialog();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEvents();
            LoadAttendees();
        }
    }
}