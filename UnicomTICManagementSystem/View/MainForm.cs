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
        private string userRole;
        public MainForm(string role) 
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          StudentForm studentForm = new StudentForm(userRole);
          LoadFormInPanel(studentForm);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_course_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm(userRole);
            LoadFormInPanel(courseForm);
        }

        private void btn_lecture_Click(object sender, EventArgs e)
        {
            LectureForm lectureForm = new LectureForm(userRole);
            LoadFormInPanel(lectureForm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StaffForm  staffForm = new StaffForm(userRole);
            LoadFormInPanel(staffForm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm(userRole);
            LoadFormInPanel(roomForm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm(userRole);   
            LoadFormInPanel(subjectForm);
        }

        private void btn_exam_Click(object sender, EventArgs e)
        {
            ExamForm examForm = new ExamForm(userRole);
            LoadFormInPanel(examForm);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TimetableForm timetableForm = new TimetableForm(userRole);
            LoadFormInPanel(timetableForm);
        }

        private void btn_mark_Click(object sender, EventArgs e)
        {
            MarkForm markForm = new MarkForm(userRole);
            LoadFormInPanel(markForm);
        }
    }
}
