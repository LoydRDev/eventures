using System;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace eventures.Validation
{
    public static class EventFormValidation
    {
        private static readonly Color ErrorColor = Color.LightPink;
        private static readonly Color ValidColor = SystemColors.Window;

        // EventDetails form validation
        public static bool ValidateEventDetails(BunifuTextBox eventNameBox, BunifuTextBox descriptionBox, ComboBox categoryBox, ErrorProvider errorProvider)
        {
            bool isValid = true;

            // Event Name validation
            if (string.IsNullOrWhiteSpace(eventNameBox.Text) || eventNameBox.Text.Length > 100)
            {
                errorProvider.SetError(eventNameBox, "Event name is required and must not exceed 100 characters");
                eventNameBox.BackColor = ErrorColor;
                isValid = false;
            }
            else
            {
                errorProvider.SetError(eventNameBox, "");
                eventNameBox.BackColor = ValidColor;
            }

            // Description validation (optional but max 255 chars)
            if (!string.IsNullOrWhiteSpace(descriptionBox.Text) && descriptionBox.Text.Length > 255)
            {
                errorProvider.SetError(descriptionBox, "Description must not exceed 255 characters");
                descriptionBox.BackColor = ErrorColor;
                isValid = false;
            }
            else
            {
                errorProvider.SetError(descriptionBox, "");
                descriptionBox.BackColor = ValidColor;
            }

            // Category validation
            if (string.IsNullOrWhiteSpace(categoryBox.Text) || categoryBox.Text.Length > 50)
            {
                errorProvider.SetError(categoryBox, "Category is required and must not exceed 50 characters");
                categoryBox.BackColor = ErrorColor;
                isValid = false;
            }
            else
            {
                errorProvider.SetError(categoryBox, "");
                categoryBox.BackColor = ValidColor;
            }

            return isValid;
        }

        // DateAndLocation form validation
        public static bool ValidateDateAndLocation(BunifuDatePicker eventDatePicker, BunifuDatePicker eventDateStart, BunifuDatePicker eventDateEnd, BunifuTextBox locationBox, ErrorProvider errorProvider)
        {
            bool isValid = true;

            // Event Date validation
            if (eventDatePicker.Value.Date < DateTime.Now.Date)
            {
                errorProvider.SetError(eventDatePicker, "Event date cannot be in the past");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(eventDatePicker, "");
            }

            // Event Date Start validation
            if (eventDateStart.Value.Date < eventDateStart.Value.Date)
            {
                errorProvider.SetError(eventDateStart, "Event start date cannot be before the event date");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(eventDateStart, "");
            }

            // Location validation
            if (string.IsNullOrWhiteSpace(locationBox.Text) || locationBox.Text.Length > 100)
            {
                errorProvider.SetError(locationBox, "Location is required and must not exceed 100 characters");
                locationBox.BackColor = ErrorColor;
                isValid = false;
            }
            else
            {
                errorProvider.SetError(locationBox, "");
                locationBox.BackColor = ValidColor;
            }

            return isValid;
        }

        // Participants form validation
        public static bool ValidateParticipants(NumericUpDown capacityUpDown, ErrorProvider errorProvider)
        {
            bool isValid = true;

            // Capacity validation
            if (capacityUpDown.Value < 1)
            {
                errorProvider.SetError(capacityUpDown, "Capacity must be at least 1");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(capacityUpDown, "");
            }

            return isValid;
        }
    }
}