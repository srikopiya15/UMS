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
    public partial class CourseForm : Form
    {
        private CourseController courseController =new CourseController();
        private int course_id = -1;
        public CourseForm()
        {
            InitializeComponent();
            this.Load += CourseForm_Load;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void CourseForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }
        private async Task LoadCourses()
        {
            dvg_course.DataSource=await courseController.GetAllCourseAsync();
        }

        private async void add_btn_Click(object sender, EventArgs e)
        {
            string name = course_combo.Text;
            DateTime startdate = startdate_pick.Value;
            DateTime enddate = enddate_pick.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the course name.");
                return;
            }

            if (enddate < startdate)
            {
                MessageBox.Show("End date cannot be before start date.");
                return;
            }

            await courseController.AddAsync(new Course
            {
                CourseName = name,
                StartDate = startdate,
                EndDate = enddate,
            });

            await LoadCourses();
            MessageBox.Show("Added Successfully.");
        }


        private async void update_btn_Click(object sender, EventArgs e)
        {
            if (course_id != -1)
            {
                await courseController.UpdateAsync(new Course
                {
                    courseId = course_id,
                    CourseName = course_combo.Text,
                    StartDate = startdate_pick.Value,
                    EndDate = enddate_pick.Value
                });
                course_id = -1;
                course_combo.SelectedIndex = -1;
                await LoadCourses();
                MessageBox.Show("Updated Successfully.");
            }
            else
            {
                MessageBox.Show("Select a course to update.");
            }
        }


        private async void delete_btn_Click(object sender, EventArgs e)
        {
            if (course_id != -1)
            {
                await courseController.DeleteAsync(course_id);
                course_id = -1;
                course_combo.SelectedIndex = -1;
                await LoadCourses();
                MessageBox.Show("Deleted Successfully.");
            }
            else
            {
                MessageBox.Show("Select a course to delete.");
            }
        }


        private async void dvg_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row=dvg_course.Rows[e.RowIndex];
                course_id = Convert.ToInt32(row.Cells["CourseID"].Value);
                course_combo.Text = row.Cells["CourseName"].Value.ToString();
                await LoadCourses();
            }
        }

        private void course_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
