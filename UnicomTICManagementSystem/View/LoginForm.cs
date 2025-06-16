using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTICManagementSystem.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
           
        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string[,] credendials = new string[,]
{
            {"Admin", "admin", "admin@123"},
            {"Lecture", "lecture", "lecture@123"},
            {"Staff", "staff", "staff@123"},
            {"Student", "student", "student@123"}
};

            string role = comboBox1.Text.Trim();
            string username = username_txt.Text.Trim();
            string password = password_txt.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValid = false;
            for (int i = 0; i < credendials.GetLength(0); i++)
            {
                if (credendials[i, 0] == role &&
                    credendials[i, 1] == username &&
                    credendials[i, 2] == password)
                {
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                MessageBox.Show($"Login successful as {role}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
         
        }
    }
}
