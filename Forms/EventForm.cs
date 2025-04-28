using System;
using System.Windows.Forms;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{
    public partial class EventForm : Form
    {
        private Event currentEvent;
        private bool isEditMode;

        public EventForm(Event evt = null)
        {
            InitializeComponent();
            isEditMode = evt != null;
            currentEvent = evt ?? new Event();
            if (isEditMode)
            {
                LoadEventData();
            }
        }

        private void LoadEventData()
        {
            txtEventName.Text = currentEvent.EventName;
            txtDescription.Text = currentEvent.Description;
            dtpEventDate.Value = currentEvent.EventDate;
            txtLocation.Text = currentEvent.Location;
            numMaxAttendees.Value = currentEvent.MaxAttendees;
            cboStatus.Text = currentEvent.Status;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Please enter an event name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter a location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpEventDate.Value < DateTime.Today)
            {
                MessageBox.Show("Event date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numMaxAttendees.Value <= 0)
            {
                MessageBox.Show("Maximum attendees must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                currentEvent.EventName = txtEventName.Text;
                currentEvent.Description = txtDescription.Text;
                currentEvent.EventDate = dtpEventDate.Value;
                currentEvent.Location = txtLocation.Text;
                currentEvent.MaxAttendees = (int)numMaxAttendees.Value;
                currentEvent.Status = cboStatus.Text;

                if (isEditMode)
                {
                    EventDAO.UpdateEvent(currentEvent);
                }
                else
                {
                    currentEvent.CreatedDate = DateTime.Now;
                    currentEvent.LastModifiedDate = DateTime.Now;
                    EventDAO.CreateEvent(currentEvent);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}