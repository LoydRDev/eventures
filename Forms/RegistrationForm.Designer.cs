namespace eventms.Forms
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEventDetails = new System.Windows.Forms.Label();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.lblSelectAttendee = new System.Windows.Forms.Label();
            this.cboAttendee = new System.Windows.Forms.ComboBox();
            this.btnNewAttendee = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form settings
            this.Text = "Event Registration";
            this.Size = new System.Drawing.Size(500, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Event Details
            this.lblEventDetails.Location = new System.Drawing.Point(20, 20);
            this.lblEventDetails.Size = new System.Drawing.Size(440, 60);
            this.lblEventDetails.AutoSize = false;

            // Availability
            this.lblAvailability.Location = new System.Drawing.Point(20, 90);
            this.lblAvailability.Size = new System.Drawing.Size(440, 23);
            this.lblAvailability.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);

            // Select Attendee
            this.lblSelectAttendee.Text = "Select Attendee:";
            this.lblSelectAttendee.Location = new System.Drawing.Point(20, 130);
            this.lblSelectAttendee.Size = new System.Drawing.Size(100, 23);

            this.cboAttendee.Location = new System.Drawing.Point(130, 130);
            this.cboAttendee.Size = new System.Drawing.Size(220, 23);
            this.cboAttendee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnNewAttendee.Text = "New Attendee";
            this.btnNewAttendee.Location = new System.Drawing.Point(360, 130);
            this.btnNewAttendee.Size = new System.Drawing.Size(100, 23);
            this.btnNewAttendee.Click += new System.EventHandler(this.btnNewAttendee_Click);

            // Notes
            this.lblNotes.Text = "Notes:";
            this.lblNotes.Location = new System.Drawing.Point(20, 170);
            this.lblNotes.Size = new System.Drawing.Size(100, 23);

            this.txtNotes.Location = new System.Drawing.Point(130, 170);
            this.txtNotes.Size = new System.Drawing.Size(330, 100);
            this.txtNotes.Multiline = true;

            // Buttons
            this.btnRegister.Text = "Register";
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRegister.Location = new System.Drawing.Point(270, 320);
            this.btnRegister.Size = new System.Drawing.Size(80, 30);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 320);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEventDetails,
                this.lblAvailability,
                this.lblSelectAttendee,
                this.cboAttendee,
                this.btnNewAttendee,
                this.lblNotes,
                this.txtNotes,
                this.btnRegister,
                this.btnCancel
            });

            this.AcceptButton = this.btnRegister;
            this.CancelButton = this.btnCancel;
        }

        private System.Windows.Forms.Label lblEventDetails;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.Label lblSelectAttendee;
        private System.Windows.Forms.ComboBox cboAttendee;
        private System.Windows.Forms.Button btnNewAttendee;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}