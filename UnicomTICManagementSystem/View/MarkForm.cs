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
    public partial class MarkForm : Form
    {
        private MarkController MarkController=new MarkController();
        
        public MarkForm()
        {
            InitializeComponent();
            get_mark_info();
        }
        private void get_mark_info()
        {
            dgv_mark.DataSource = null;
            dgv_mark.DataSource=MarkController.GetAllMarks();
            dgv_mark.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            subject_combo.SelectedIndex = -1;
            student_combo.SelectedIndex = -1;
            type_combo.SelectedIndex = -1;
            mark_txt.Text = string.Empty;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mark_txt.Text) ||
            subject_combo.SelectedIndex == -1 ||
            student_combo.SelectedIndex == -1 ||
            type_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select subject, student,exam type and enter the mark.");
                return;
            }

            Mark mark = new Mark
            {
                MarkObtained = Convert.ToInt32(mark_txt.Text),
                SubjectId = Convert.ToInt32(subject_combo.SelectedValue), 
                StudentId = Convert.ToInt32(student_combo.SelectedValue),  
                Examtype = type_combo.SelectedItem.ToString()              
            };
            MarkController.AddMark(mark);
            get_mark_info();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mark_txt.Text) ||
            subject_combo.SelectedIndex == -1 ||
            student_combo.SelectedIndex == -1 ||
            type_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select subject and exam type.");
                return;
            }

            Mark mark = new Mark
            {
                MarkObtained = Convert.ToInt32(mark_txt.Text),
                SubjectId = Convert.ToInt32(subject_combo.SelectedValue),
                StudentId = Convert.ToInt32(student_combo.SelectedValue),
                Examtype = type_combo.SelectedItem.ToString()
            };
            MarkController.UpdateMark(mark);
            get_mark_info();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (student_combo.SelectedIndex == -1 || type_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select student and exam type.");
                return;
            }

            int studentId = Convert.ToInt32(student_combo.SelectedValue);
            string examType = type_combo.SelectedItem.ToString();

            MarkController.DeleteMark(studentId, examType);
            get_mark_info();

        }
    }
}
