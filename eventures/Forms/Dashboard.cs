using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

using eventures.Forms;
using eventures.DataAccess;
using eventures.Models;
using eventures.Properties;
using System.Resources;

namespace eventures
{
    public partial class Dashboard : Form
    {
        private string currentUsername;
        Event events = new Event();

        public Dashboard(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
        }

        private void BtnBrowseEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var browseEventForm = new BrowseEvent();
            browseEventForm.Closed += (s, args) => this.Close();
            browseEventForm.Show();
        }

        private void BtnOrganizeEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            var organizeEventForm = new OrganizeEvent();
            organizeEventForm.Closed += (s, args) => this.Close();
            organizeEventForm.Show();
        }

        private void BtnEventHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var eventHistoryForm = new EventHistory();
            eventHistoryForm.Closed += (s, args) => this.Close();
            eventHistoryForm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var currentUser = new UserDAO().GetCurrentUser(currentUsername);
            var tableRows = new EventDAO().GetTableRowsCount();

            for (int i = 0; i < tableRows; i++)
            {
                var bunifuCards = new Bunifu.Framework.UI.BunifuCards();
                bunifuCards.BackColor = System.Drawing.Color.White;
                bunifuCards.BorderRadius = 5;
                bunifuCards.BottomSahddow = true;
                bunifuCards.BottomShadow = true;
                bunifuCards.color = System.Drawing.Color.Tomato;
                bunifuCards.IndicatorColor = System.Drawing.Color.Tomato;
                bunifuCards.LeftSahddow = false;
                bunifuCards.LeftShadow = false;
                bunifuCards.Location = new System.Drawing.Point(7, 19);
                bunifuCards.Margin = new System.Windows.Forms.Padding(0, 6, 11, 6);
                bunifuCards.Name = "BunifuCards"+i;
                bunifuCards.RightSahddow = true;
                bunifuCards.RightShadow = true;
                bunifuCards.ShadowDepth = 20;
                bunifuCards.Size = new System.Drawing.Size(183, 216);
                bunifuCards.TabIndex = 10;

                var eventLogo = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
                eventLogo.AllowAnimations = true;
                eventLogo.AllowBorderColorChanges = true;
                eventLogo.AllowMouseEffects = true;
                eventLogo.AnimationSpeed = 200;
                eventLogo.BackColor = System.Drawing.Color.Transparent;
                eventLogo.BackgroundColor = System.Drawing.Color.Tomato;
                eventLogo.BorderColor = System.Drawing.Color.Tomato;
                eventLogo.BorderRadius = 1;
                eventLogo.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
                eventLogo.BorderThickness = 1;
                eventLogo.ColorContrastOnClick = 30;
                eventLogo.ColorContrastOnHover = 30;
                eventLogo.Cursor = System.Windows.Forms.Cursors.Default;
                eventLogo.DialogResult = System.Windows.Forms.DialogResult.None;
                //eventLogo.Image = ((System.Drawing.Image)(resources.GetObject("eventLogo1.Image")));
                eventLogo.ImageMargin = new System.Windows.Forms.Padding(0);
                eventLogo.Location = new System.Drawing.Point(53, 28);
                eventLogo.Name = "eventLogo"+i;
                eventLogo.RoundBorders = true;
                eventLogo.ShowBorders = true;
                eventLogo.Size = new System.Drawing.Size(75, 75);
                eventLogo.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
                eventLogo.TabIndex = 3;

                var lblEventName = new Bunifu.UI.WinForms.BunifuLabel();
                lblEventName.AllowParentOverrides = false;
                lblEventName.AutoEllipsis = false;
                lblEventName.Cursor = System.Windows.Forms.Cursors.Default;
                lblEventName.CursorType = System.Windows.Forms.Cursors.Default;
                lblEventName.Font = new System.Drawing.Font("Segoe UI", 9F);
                lblEventName.Location = new System.Drawing.Point(53, 121);
                lblEventName.Name = "lblEventName"+i;
                lblEventName.RightToLeft = System.Windows.Forms.RightToLeft.No;
                lblEventName.Size = new System.Drawing.Size(79, 15);
                lblEventName.TabIndex = 1;
                lblEventName.Text = "EventName"+1;
                lblEventName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                lblEventName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;

                var lblEventCategory = new Bunifu.UI.WinForms.BunifuLabel();
                lblEventCategory.AllowParentOverrides = false;
                lblEventCategory.AutoEllipsis = false;
                lblEventCategory.Cursor = System.Windows.Forms.Cursors.Default;
                lblEventCategory.CursorType = System.Windows.Forms.Cursors.Default;
                lblEventCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
                lblEventCategory.Location = new System.Drawing.Point(30, 142);
                lblEventCategory.Name = "LblEventCategory"+i;
                lblEventCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
                lblEventCategory.Size = new System.Drawing.Size(126, 15);
                lblEventCategory.TabIndex = 2;
                lblEventCategory.Text = "Category";
                lblEventCategory.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                lblEventCategory.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;

                var lblEventDetails = new Bunifu.UI.WinForms.BunifuLabel();
                lblEventDetails.AllowParentOverrides = false;
                lblEventDetails.AutoEllipsis = false;
                lblEventDetails.CursorType = null;
                lblEventDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                lblEventDetails.Location = new System.Drawing.Point(59, 166);
                lblEventDetails.Name = "LblEventDetails"+i;
                lblEventDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
                lblEventDetails.Size = new System.Drawing.Size(78, 15);
                lblEventDetails.TabIndex = 12;
                lblEventDetails.Text = "view details....";
                lblEventDetails.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                lblEventDetails.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;

                var bunifuButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
                bunifuButton.AllowAnimations = true;
                bunifuButton.AllowMouseEffects = true;
                bunifuButton.AllowToggling = false;
                bunifuButton.AnimationSpeed = 200;
                bunifuButton.AutoGenerateColors = false;
                bunifuButton.AutoRoundBorders = false;
                bunifuButton.AutoSizeLeftIcon = true;
                bunifuButton.AutoSizeRightIcon = true;
                bunifuButton.BackColor = System.Drawing.Color.Transparent;
                bunifuButton.BackColor1 = System.Drawing.Color.DodgerBlue;
                bunifuButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
                bunifuButton.ButtonText = "Join";
                bunifuButton.ButtonTextMarginLeft = 0;
                bunifuButton.ColorContrastOnClick = 45;
                bunifuButton.ColorContrastOnHover = 45;
                bunifuButton.Cursor = System.Windows.Forms.Cursors.Default;
                bunifuButton.DialogResult = System.Windows.Forms.DialogResult.None;
                bunifuButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
                bunifuButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                bunifuButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
                bunifuButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
                bunifuButton.Font = new System.Drawing.Font("Segoe UI", 9F);
                bunifuButton.ForeColor = System.Drawing.Color.White;
                bunifuButton.IconLeft = null;
                bunifuButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
                bunifuButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
                bunifuButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
                bunifuButton.IconMarginLeft = 11;
                bunifuButton.IconPadding = 10;
                bunifuButton.IconRight = null;
                bunifuButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
                bunifuButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
                bunifuButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
                bunifuButton.IconSize = 25;
                bunifuButton.IdleBorderColor = System.Drawing.Color.DodgerBlue;
                bunifuButton.IdleBorderRadius = 1;
                bunifuButton.IdleBorderThickness = 1;
                bunifuButton.IdleFillColor = System.Drawing.Color.DodgerBlue;
                bunifuButton.IdleIconLeftImage = null;
                bunifuButton.IdleIconRightImage = null;
                bunifuButton.IndicateFocus = false;
                bunifuButton.Location = new System.Drawing.Point(13, 187);
                bunifuButton.Name = "BtnJoin"+i;
                bunifuButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
                bunifuButton.OnDisabledState.BorderRadius = 1;
                bunifuButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
                bunifuButton.OnDisabledState.BorderThickness = 1;
                bunifuButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                bunifuButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
                bunifuButton.OnDisabledState.IconLeftImage = null;
                bunifuButton.OnDisabledState.IconRightImage = null;
                bunifuButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
                bunifuButton.onHoverState.BorderRadius = 1;
                bunifuButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
                bunifuButton.onHoverState.BorderThickness = 1;
                bunifuButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
                bunifuButton.onHoverState.ForeColor = System.Drawing.Color.White;
                bunifuButton.onHoverState.IconLeftImage = null;
                bunifuButton.onHoverState.IconRightImage = null;
                bunifuButton.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
                bunifuButton.OnIdleState.BorderRadius = 1;
                bunifuButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
                bunifuButton.OnIdleState.BorderThickness = 1;
                bunifuButton.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
                bunifuButton.OnIdleState.ForeColor = System.Drawing.Color.White;
                bunifuButton.OnIdleState.IconLeftImage = null;
                bunifuButton.OnIdleState.IconRightImage = null;
                bunifuButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
                bunifuButton.OnPressedState.BorderRadius = 1;
                bunifuButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
                bunifuButton.OnPressedState.BorderThickness = 1;
                bunifuButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
                bunifuButton.OnPressedState.ForeColor = System.Drawing.Color.White;
                bunifuButton.OnPressedState.IconLeftImage = null;
                bunifuButton.OnPressedState.IconRightImage = null;
                bunifuButton.Size = new System.Drawing.Size(158, 19);
                bunifuButton.TabIndex = 13;
                bunifuButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                bunifuButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
                bunifuButton.TextMarginLeft = 0;
                bunifuButton.TextPadding = new System.Windows.Forms.Padding(0);
                bunifuButton.UseDefaultRadiusAndThickness = true;

                bunifuCards.Controls.Add(eventLogo);
                bunifuCards.Controls.Add(lblEventName);
                bunifuCards.Controls.Add(lblEventCategory);
                bunifuCards.Controls.Add(lblEventDetails);
                bunifuCards.Controls.Add(bunifuButton);

                flowLayoutPanel1.Controls.Add(bunifuCards);
            }
        }
    }
}
