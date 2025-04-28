using System;
using System.Windows.Forms;
using eventms.Models;
using eventms.DataAccess;

namespace eventms.Forms
{
    public partial class RegistrationStatusForm : Form
    {
        private Registration currentRegistration;

        public RegistrationStatusForm(Registration registration)
        {
            InitializeComponent();
            currentRegistration = registration;
            LoadRegistrationData();
        }

        private void LoadRegistrationData()
        {
            cboStatus.Text = currentRegistration.Status;
            cboAttendanceStatus.Text = currentRegistration.AttendanceStatus;
            chkHasAttended.Checked = currentRegistration.HasAttended;
            txtNotes.Text = currentRegistration.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                currentRegistration.Status = cboStatus.Text;
                currentRegistration.AttendanceStatus = cboAttendanceStatus.Text;
                currentRegistration.HasAttended = chkHasAttended.Checked;
                currentRegistration.Notes = txtNotes.Text;

                RegistrationDAO.UpdateRegistration(currentRegistration);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}