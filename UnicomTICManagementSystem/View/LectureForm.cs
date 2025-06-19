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
        public LectureForm()
        {
            InitializeComponent();
            get_lecture_info();

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
            Lecture lecture = new Lecture
            {
                Name = name_txt.Text,
                Address = address_txt.Text,
                Email = email_txt.Text,
            };
            LectureController lectureController = new LectureController(lecture);

            get_lecture_info();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
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

                int lec_id = Convert.ToInt32(dgv_lecture.SelectedRows[0].Cells["ID"].Value);

                Lecture lecture = new Lecture
                {
                    Id = lec_id,
                    Name = name_txt.Text,
                    Address = address_txt.Text,
                    Email = email_txt.Text,
                };

                LectureController lectureController = new LectureController(lecture);
                lectureController.UpdateLecture(lecture);

                get_lecture_info();
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
                    Id = lec_id
                };

                LectureController lectureController = new LectureController(lecture);
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

                lec_id = lecture.Id;
                name_txt.Text = lecture.Name;
                address_txt.Text = lecture.Address;
                email_txt.Text = lecture.Email;
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
