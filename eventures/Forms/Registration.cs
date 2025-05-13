using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using eventures.Models;
using eventures.DataAccess;

namespace eventures
{
    public partial class Registration: Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Validate First Name
            string namePattern = @"^[a-zA-Z\s-]+$";
            if (string.IsNullOrWhiteSpace(TBUserFirstName.Text) || !Regex.IsMatch(TBUserFirstName.Text, namePattern))
            {
                TBUserFirstName.BorderColorIdle = Color.Red;
                isValid = false;
                if (!string.IsNullOrWhiteSpace(TBUserFirstName.Text) && !Regex.IsMatch(TBUserFirstName.Text, namePattern))
                {
                    MessageBox.Show("First name should only contain letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                TBUserFirstName.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(TBUserLastName.Text) || !Regex.IsMatch(TBUserLastName.Text, namePattern))
            {
                TBUserLastName.BorderColorIdle = Color.Red;
                isValid = false;
                if (!string.IsNullOrWhiteSpace(TBUserLastName.Text) && !Regex.IsMatch(TBUserLastName.Text, namePattern))
                {
                    MessageBox.Show("Last name should only contain letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                TBUserLastName.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(TBUserLastName.Text) || !Regex.IsMatch(TBUserLastName.Text, emailPattern))
            {
                TBUserLastName.BorderColorIdle = Color.Red;
                isValid = false;
            }
            else
            {
                TBUserLastName.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Phone Number
            string phonePattern = @"^\+?[0-9]{10,15}$";
            if (string.IsNullOrWhiteSpace(TBUserEmail.Text) || !Regex.IsMatch(TBUserEmail.Text, phonePattern))
            {
                TBUserEmail.BorderColorIdle = Color.Red;
                isValid = false;
            }
            else
            {
                TBUserEmail.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Username
            if (string.IsNullOrWhiteSpace(TBUsername.Text) || TBUsername.Text.Length < 3)
            {
                TBUsername.BorderColorIdle = Color.Red;
                isValid = false;
            }
            else
            {
                TBUsername.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(TBUserPassword2.Text) || TBUserPassword2.Text.Length < 6)
            {
                TBUserPassword2.BorderColorIdle = Color.Red;
                isValid = false;
            }
            else
            {
                TBUserPassword2.BorderColorIdle = Color.FromArgb(1, 88, 122);
            }

            // Validate Password Confirmation
            if (TBUserPassword.Text != TBUserPassword2.Text)
            {
                TBUserPassword.BorderColorIdle = Color.Red;
                TBUserPassword2.BorderColorIdle = Color.Red;
                isValid = false;
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!isValid)
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginPage();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void BtnCreateUser_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                User newUser = new User
                {
                    FirstName = TBUserFirstName.Text,
                    LastName = TBUserLastName.Text,
                    Username = TBUsername.Text,
                    Email = TBUserEmail.Text,
                    Password = TBUserPassword2.Text
                };

                try
                {
                    new UserDAO().AddUser(newUser);
                    MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
