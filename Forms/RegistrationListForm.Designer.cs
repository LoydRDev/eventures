namespace eventms.Forms
{
    partial class RegistrationsListForm
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
            this.lblRegistrationCount = new System.Windows.Forms.Label();
            this.dgvRegistrations = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnSendNotification = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // Form settings
            this.Text = "Event Registrations";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Event Details
            this.lblEventDetails.Location = new System.Drawing.Point(20, 20);
            this.lblEventDetails.Size = new System.Drawing.Size(500, 60);
            this.lblEventDetails.AutoSize = false;

            // Registration Count
            this.lblRegistrationCount.Location = new System.Drawing.Point(20, 90);
            this.lblRegistrationCount.Size = new System.Drawing.Size(500, 23);
            this.lblRegistrationCount.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);

            // DataGridView
            this.dgvRegistrations.Location = new System.Drawing.Point(20, 130);
            this.dgvRegistrations.Size = new System.Drawing.Size(740, 370);
            this.dgvRegistrations.AllowUserToAddRows = false;
            this.dgvRegistrations.AllowUserToDeleteRows = false;
            this.dgvRegistrations.MultiSelect = false;
            this.dgvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistrations.ReadOnly = true;
            this.dgvRegistrations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Buttons
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Location = new System.Drawing.Point(20, 520);
            this.btnUpdateStatus.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            this.btnSendNotification.Text = "Send Notification";
            this.btnSendNotification.Location = new System.Drawing.Point(160, 520);
            this.btnSendNotification.Size = new System.Drawing.Size(120, 30);
            this.btnSendNotification.Click += new System.EventHandler(this.btnSendNotification_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(300, 520);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnClose.Text = "Close";
            this.btnClose.Location = new System.Drawing.Point(640, 520);
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEventDetails,
                this.lblRegistrationCount,
                this.dgvRegistrations,
                this.btnUpdateStatus,
                this.btnSendNotification,
                this.btnRefresh,
                this.btnClose
            });
        }

        private System.Windows.Forms.Label lblEventDetails;
        private System.Windows.Forms.Label lblRegistrationCount;
        private System.Windows.Forms.DataGridView dgvRegistrations;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnSendNotification;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        #endregion
    }
}