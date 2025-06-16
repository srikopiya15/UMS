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
    public partial class CourseForm : Form
    {
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

        }
    }
}
