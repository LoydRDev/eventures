namespace eventms.Forms
{
    partial class EventForm
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
            this.lblEventName = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblMaxAttendees = new System.Windows.Forms.Label();
            this.numMaxAttendees = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form settings
            this.Text = "Event Details";
            this.Size = new System.Drawing.Size(500, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Event Name
            this.lblEventName.Text = "Event Name:";
            this.lblEventName.Location = new System.Drawing.Point(20, 20);
            this.lblEventName.Size = new System.Drawing.Size(100, 23);

            this.txtEventName.Location = new System.Drawing.Point(130, 20);
            this.txtEventName.Size = new System.Drawing.Size(320, 23);

            // Description
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 60);
            this.lblDescription.Size = new System.Drawing.Size(100, 23);

            this.txtDescription.Location = new System.Drawing.Point(130, 60);
            this.txtDescription.Size = new System.Drawing.Size(320, 80);
            this.txtDescription.Multiline = true;

            // Event Date
            this.lblEventDate.Text = "Event Date:";
            this.lblEventDate.Location = new System.Drawing.Point(20, 160);
            this.lblEventDate.Size = new System.Drawing.Size(100, 23);

            this.dtpEventDate.Location = new System.Drawing.Point(130, 160);
            this.dtpEventDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpEventDate.ShowUpDown = true;

            // Location
            this.lblLocation.Text = "Location:";
            this.lblLocation.Location = new System.Drawing.Point(20, 200);
            this.lblLocation.Size = new System.Drawing.Size(100, 23);

            this.txtLocation.Location = new System.Drawing.Point(130, 200);
            this.txtLocation.Size = new System.Drawing.Size(320, 23);

            // Max Attendees
            this.lblMaxAttendees.Text = "Max Attendees:";
            this.lblMaxAttendees.Location = new System.Drawing.Point(20, 240);
            this.lblMaxAttendees.Size = new System.Drawing.Size(100, 23);

            this.numMaxAttendees.Location = new System.Drawing.Point(130, 240);
            this.numMaxAttendees.Size = new System.Drawing.Size(100, 23);
            this.numMaxAttendees.Minimum = 1;
            this.numMaxAttendees.Maximum = 1000;
            this.numMaxAttendees.Value = 50;

            // Status
            this.lblStatus.Text = "Status:";
            this.lblStatus.Location = new System.Drawing.Point(20, 280);
            this.lblStatus.Size = new System.Drawing.Size(100, 23);

            this.cboStatus.Location = new System.Drawing.Point(130, 280);
            this.cboStatus.Size = new System.Drawing.Size(150, 23);
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Items.AddRange(new object[] { "Planned", "Open", "Closed", "Cancelled" });

            // Buttons
            this.btnSave.Text = "Save";
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(270, 320);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 320);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEventName,
                this.txtEventName,
                this.lblDescription,
                this.txtDescription,
                this.lblEventDate,
                this.dtpEventDate,
                this.lblLocation,
                this.txtLocation,
                this.lblMaxAttendees,
                this.numMaxAttendees,
                this.lblStatus,
                this.cboStatus,
                this.btnSave,
                this.btnCancel
            });

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
        }

        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblMaxAttendees;
        private System.Windows.Forms.NumericUpDown numMaxAttendees;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}