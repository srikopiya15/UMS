using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Forms
{
    public partial class StudentForm : Form

    {
        private StudentController studentController = new StudentController();
        private int stu_id=-1;
        public StudentForm()
        {
            InitializeComponent();
            get_student_info();
        } 
        private void get_student_info() 
        {
            DGVstudent.DataSource = null;
            DGVstudent.DataSource=studentController.ShowOutput();
            DGVstudent.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            txt_name.Text = string.Empty;
            txt_address.Text = string.Empty;
            comboBox1.Text = string.Empty;
            stu_id = -1;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(txt_name.Text)|| string.IsNullOrWhiteSpace(txt_address.Text)) 
           { 
                MessageBox.Show("Please enter the name and address.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

           }
           Student student = new Student
            {
                Name = txt_name.Text,
                Address = txt_address.Text,
                Stream = comboBox1.Text,
            };
            StudentController studentcontroller=new StudentController(student);

            get_student_info();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (DGVstudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_address.Text))
            {
                MessageBox.Show("Please enter the name and address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
    
            int stu_id = Convert.ToInt32(DGVstudent.SelectedRows[0].Cells["ID"].Value);

            Student student = new Student
            {
                Id = stu_id, 
                Name = txt_name.Text,
                Address = txt_address.Text,
                Stream = comboBox1.Text,
            };

            StudentController studentcontroller = new StudentController();
            studentcontroller.UpdateStudent(student);

            get_student_info();
        }


        private void DGVstudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVstudent.SelectedRows.Count > 0) 
            { 
                var row = DGVstudent.SelectedRows[0];
                var student = (Student)row.DataBoundItem;

                stu_id=student.Id;
                txt_name.Text = student.Name;
                txt_address.Text = student.Address;
                comboBox1.Text = student.Stream;
            }
            else 
            {  
                ClearInputs();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

            if (DGVstudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stu_id = Convert.ToInt32(DGVstudent.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show("Are you sure want to delete the student?","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                Student student = new Student
                {
                    Id = stu_id
                };

                StudentController studentcontroller = new StudentController();
                studentcontroller.DeleteStudent(student);

                get_student_info();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStream=comboBox1.SelectedItem.ToString();
            MessageBox.Show("You selected:" + selectedStream);
            comboBox1.Text = selectedStream;

            comboBox1.Items.Add(selectedStream);

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
