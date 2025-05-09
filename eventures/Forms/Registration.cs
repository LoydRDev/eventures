using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eventures.DataAccess;
using eventures.Database;
using eventures.Models;

namespace eventures
{
    public partial class Registration: Form
    {
        RegistrationDAO register = new RegistrationDAO();
        public Registration()
        {
            InitializeComponent();
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginPage();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(bunifuTextBox1.Text) || string.IsNullOrWhiteSpace(bunifuTextBox3.Text) ||
                    string.IsNullOrWhiteSpace(bunifuTextBox6.Text) || string.IsNullOrWhiteSpace(bunifuTextBox4.Text) ||
                    string.IsNullOrWhiteSpace(bunifuTextBox5.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password match
                if (bunifuTextBox4.Text != bunifuTextBox5.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create user object
                var user = new User
                {
                    FirstName = bunifuTextBox1.Text,
                    LastName = bunifuTextBox3.Text,
                    Username = bunifuTextBox6.Text,
                    Password = bunifuTextBox4.Text
                };

                // Register user using DAO
                if (RegistrationDAO.RegisterUser(user))
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    var login = new LoginPage();
                    login.Closed += (s, args) => this.Close();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
