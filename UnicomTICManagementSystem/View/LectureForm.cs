using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnicomTICManagementSystem.View
{
    public partial class LectureForm : Form
    {

        private LectureController lectureController=new LectureController();
        private int lec_id = -1;
        string userRole;
        public LectureForm(string role)
        {
            InitializeComponent();
            userRole = role;
            ApplyPermission();
            get_lecture_info();
           
        }
        private void ApplyPermission()
        {
            if (userRole != "Admin")
            {
                btn_add.Visible = false;
                btn_delete.Visible = false;
                btn_update.Visible = false;
            }
        }
        private void get_lecture_info() 
        {
            dgv_lecture.DataSource=null;
            dgv_lecture.DataSource = lectureController.ShowOutput();
            dgv_lecture.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            name_txt.Text = string.Empty;
            address_txt.Text = string.Empty;
            email_txt.Text = string.Empty;
            lec_id = -1;  
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_txt.Text) || string.IsNullOrWhiteSpace(address_txt.Text))
            {
                MessageBox.Show("Please enter the name and address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Lecture lecture = new Lecture
                {
                    LecturerName = name_txt.Text,
                    LecturerAddress = address_txt.Text,
                    LecturerEmail = email_txt.Text,
                };

                lectureController.AddLecture(lecture);
                get_lecture_info();  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding lecture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dgv_lecture.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a lecture to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name_txt.Text) || string.IsNullOrWhiteSpace(address_txt.Text))
            {
                MessageBox.Show("Please enter the name and address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int lec_id = Convert.ToInt32(dgv_lecture.SelectedRows[0].Cells["ID"].Value);

                
                Lecture lecture = new Lecture
                {
                    LecturerId = lec_id,
                    LecturerName = name_txt.Text,
                    LecturerAddress = address_txt.Text,
                    LecturerEmail = email_txt.Text,
                };

             
                lectureController.UpdateLecture(lecture);

               
                get_lecture_info();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the lecture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_lecture.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a lecture to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int lec_id = Convert.ToInt32(dgv_lecture.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show("Are you sure want to delete the lecture?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Lecture lecture = new Lecture
                {
                    LecturerId = lec_id
                };

                LectureController lectureController = new LectureController();
                lectureController.DeleteLecture(lecture);

                get_lecture_info();
            }
        }

        private void dgv_lecture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_lecture.SelectedRows.Count > 0)
            {
                var row = dgv_lecture.SelectedRows[0];
                var lecture = (Lecture)row.DataBoundItem;
                
                    lec_id = lecture.LecturerId;
                    name_txt.Text = lecture.LecturerName;
                    address_txt.Text = lecture.LecturerAddress;
                    email_txt.Text = lecture.LecturerEmail;
               
            }
            else
            {
                ClearInputs();
            }
        }

        private void name_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
