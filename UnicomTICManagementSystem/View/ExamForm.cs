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

namespace UnicomTICManagementSystem.View
{
    public partial class ExamForm : Form
    {
        private ExamController examcontroller=new ExamController();
        private int ex_id = -1;

        public ExamForm()
        {
            InitializeComponent();
            get_exam_info();
        }
        private void get_exam_info() 
        {
            dgv_exam.DataSource = null;
            dgv_exam.DataSource = examcontroller.ShowAllExam();
            dgv_exam.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            name_txt.Text = string.Empty;
            subject_combo.SelectedIndex = -1;
            ex_id = -1;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ex_id == -1)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            Exam exam = new Exam
            {
                Id = ex_id,
                Name = name_txt.Text,
                SubjectId = subject_combo.Text,
            };

            examcontroller.UpdateExam(exam);
            get_exam_info();
        }

        private void dgv_exam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_exam.SelectedRows.Count > 0)
            {
                var exam = (Exam)dgv_exam.SelectedRows[0].DataBoundItem;
                ex_id = exam.Id;
                name_txt.Text = exam.Name;
                subject_combo.SelectedValue = exam.SubjectId;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_txt.Text) || subject_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter exam name and select a subject.");
                return;
            }

            Exam exam = new Exam
            {
                Name = name_txt.Text,
                SubjectId = subject_combo.Text,
            };

            examcontroller.AddExam(exam);
            get_exam_info();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ex_id == -1)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            examcontroller.DeleteExam(ex_id);
            get_exam_info();
        }
    }
}
