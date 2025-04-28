namespace eventms.Forms
{
    partial class AttendeeForm
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.txtOrganization = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form settings
            this.Text = "Attendee Details";
            this.Size = new System.Drawing.Size(400, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // First Name
            this.lblFirstName.Text = "First Name:";
            this.lblFirstName.Location = new System.Drawing.Point(20, 20);
            this.lblFirstName.Size = new System.Drawing.Size(100, 23);

            this.txtFirstName.Location = new System.Drawing.Point(130, 20);
            this.txtFirstName.Size = new System.Drawing.Size(220, 23);

            // Last Name
            this.lblLastName.Text = "Last Name:";
            this.lblLastName.Location = new System.Drawing.Point(20, 60);
            this.lblLastName.Size = new System.Drawing.Size(100, 23);

            this.txtLastName.Location = new System.Drawing.Point(130, 60);
            this.txtLastName.Size = new System.Drawing.Size(220, 23);

            // Email
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(20, 100);
            this.lblEmail.Size = new System.Drawing.Size(100, 23);

            this.txtEmail.Location = new System.Drawing.Point(130, 100);
            this.txtEmail.Size = new System.Drawing.Size(220, 23);

            // Phone
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(20, 140);
            this.lblPhone.Size = new System.Drawing.Size(100, 23);

            this.txtPhone.Location = new System.Drawing.Point(130, 140);
            this.txtPhone.Size = new System.Drawing.Size(220, 23);

            // Organization
            this.lblOrganization.Text = "Organization:";
            this.lblOrganization.Location = new System.Drawing.Point(20, 180);
            this.lblOrganization.Size = new System.Drawing.Size(100, 23);

            this.txtOrganization.Location = new System.Drawing.Point(130, 180);
            this.txtOrganization.Size = new System.Drawing.Size(220, 23);

            // Buttons
            this.btnSave.Text = "Save";
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(170, 220);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 220);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFirstName,
                this.txtFirstName,
                this.lblLastName,
                this.txtLastName,
                this.lblEmail,
                this.txtEmail,
                this.lblPhone,
                this.txtPhone,
                this.lblOrganization,
                this.txtOrganization,
                this.btnSave,
                this.btnCancel
            });

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
        }

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.TextBox txtOrganization;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}