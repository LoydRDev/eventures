namespace eventms.Forms
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.tabAttendees = new System.Windows.Forms.TabPage();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.dgvAttendees = new System.Windows.Forms.DataGridView();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnViewRegistrations = new System.Windows.Forms.Button();
            this.btnManageNotifications = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelEventButtons = new System.Windows.Forms.Panel();

            // Form settings
            this.Text = "Event Manager System";
            this.Size = new System.Drawing.Size(1024, 768);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Tab Control
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Controls.Add(this.tabEvents);
            this.tabControl.Controls.Add(this.tabAttendees);

            // Events Tab
            this.tabEvents.Text = "Events";
            this.tabEvents.Controls.Add(this.dgvEvents);
            this.tabEvents.Controls.Add(this.panelEventButtons);

            // Attendees Tab
            this.tabAttendees.Text = "Attendees";
            this.tabAttendees.Controls.Add(this.dgvAttendees);

            // Events DataGridView
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.MultiSelect = false;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Attendees DataGridView
            this.dgvAttendees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendees.AllowUserToAddRows = false;
            this.dgvAttendees.MultiSelect = false;
            this.dgvAttendees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Buttons Panel
            this.panelEventButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEventButtons.Height = 50;
            this.panelEventButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnCreateEvent,
                this.btnEditEvent,
                this.btnDeleteEvent,
                this.btnRegister,
                this.btnViewRegistrations,
                this.btnManageNotifications,
                this.btnRefresh
            });

            // Button properties
            this.btnCreateEvent.Text = "Create Event";
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);

            this.btnEditEvent.Text = "Edit Event";
            this.btnEditEvent.Click += new System.EventHandler(this.btnEditEvent_Click);

            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);

            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnViewRegistrations.Text = "View Registrations";
            this.btnViewRegistrations.Click += new System.EventHandler(this.btnViewRegistrations_Click);

            this.btnManageNotifications.Text = "Manage Notifications";
            this.btnManageNotifications.Click += new System.EventHandler(this.btnManageNotifications_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Layout buttons
            int buttonWidth = 120;
            int buttonHeight = 30;
            int buttonSpacing = 10;
            int currentX = buttonSpacing;

            // Add controls to form
            this.Controls.Add(this.tabControl);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabAttendees;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.DataGridView dgvAttendees;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Button btnEditEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnViewRegistrations;
        private System.Windows.Forms.Button btnManageNotifications;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelEventButtons;

        #endregion
    }
}