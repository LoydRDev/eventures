using System;
using System.Windows.Forms;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{   
    public partial class AttendeeForm : Form
    {
        private Attendee currentAttendee;
        private bool isEditMode;

        public AttendeeForm(Attendee attendee = null)
        {
            InitializeComponent();
            isEditMode = attendee != null;
            currentAttendee = attendee ?? new Attendee();
            if (isEditMode)
            {
                LoadAttendeeData();
            }
        }

        private void LoadAttendeeData()
        {
            txtFirstName.Text = currentAttendee.FirstName;
            txtLastName.Text = currentAttendee.LastName;
            txtEmail.Text = currentAttendee.Email;
            txtPhone.Text = currentAttendee.Phone;
            txtOrganization.Text = currentAttendee.Organization;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter a first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter a last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                currentAttendee.FirstName = txtFirstName.Text;
                currentAttendee.LastName = txtLastName.Text;
                currentAttendee.Email = txtEmail.Text;
                currentAttendee.Phone = txtPhone.Text;
                currentAttendee.Organization = txtOrganization.Text;

                if (isEditMode)
                {
                    AttendeeDAO.UpdateAttendee(currentAttendee);
                }
                else
                {
                    currentAttendee.RegistrationDate = DateTime.Now;
                    AttendeeDAO.CreateAttendee(currentAttendee);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving attendee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}