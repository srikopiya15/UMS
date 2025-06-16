using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Forms;

namespace UnicomTICManagementSystem.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadFormInPanel(Form childForm)
        {
            panel4.Controls.Clear();               
            childForm.TopLevel = false;            
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;       
            panel4.Controls.Add(childForm);       
            childForm.Show();                      
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            LoadFormInPanel(loginForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          StudentForm studentForm = new StudentForm();
          LoadFormInPanel(studentForm);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
