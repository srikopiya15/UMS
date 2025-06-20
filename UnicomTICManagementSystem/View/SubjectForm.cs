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
    public partial class SubjectForm : Form
    {
        private SubjectController subjectController=new SubjectController();
        private int sub_id = -1;

        public SubjectForm()
        {
            InitializeComponent();
            get_subject_info();
        }
        private void get_subject_info() 
        {
            dgv_subject.DataSource = null;
            dgv_subject.DataSource = subjectController.ShowAllSubjects();
            dgv_subject.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            subject_txt.Text = string.Empty;
            course_combo.SelectedIndex = -1;
            sub_id = -1;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_subject.SelectedRows.Count > 0)
            {
                var subject = (Subject)dgv_subject.SelectedRows[0].DataBoundItem;
                sub_id = subject.SubjectId;
                subject_txt.Text = subject.SubjectName;
                course_combo.SelectedValue = subject.CourseID;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(subject_txt.Text) || course_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter subject name and select a course.");
                return;
            }

            Subject subject = new Subject
            {
                SubjectName = subject_txt.Text,
                CourseID = course_combo.Text,
            };

            subjectController.AddSubject(subject);
            get_subject_info();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (sub_id == -1)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            Subject subject = new Subject
            {
                SubjectId = sub_id,
                SubjectName = subject_txt.Text,
                CourseID = course_combo.Text,
            };

            subjectController.UpdateSubject(subject);
            get_subject_info();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (sub_id == -1)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            subjectController.DeleteSubject(sub_id);
            get_subject_info();
        }
    }
 
}
