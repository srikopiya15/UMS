using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.View
{
    public partial class TimetableForm : Form
    {
        private TimetableController timetablecontroller = new TimetableController();
        private int table_id = -1;
        public TimetableForm()
        {
            InitializeComponent();
            get_table_info();
        }
        private void get_table_info() 
        {
            dgv_timetable.DataSource = null;
            dgv_timetable.DataSource = timetablecontroller.ShowAllTimetable();
            dgv_timetable.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            timeslot_txt.Text = string.Empty;
            subject_combo.SelectedIndex = -1;
            room_combo.SelectedIndex = -1;
            table_id = -1;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(timeslot_txt.Text) || subject_combo.SelectedIndex == -1|| room_combo.SelectedIndex==-1)
            {
                MessageBox.Show("Please select subject,timeslot name and select a room.");
                return;
            }

            Timetable timetable = new Timetable
            {
                TimetableId = table_id,
                SubjectId = Convert.ToInt32(subject_combo.SelectedIndex),
                Timeslot = timeslot_txt.Text,
                RoomId = Convert.ToInt32(room_combo.SelectedIndex),
            };
            timetablecontroller.AddTimetable(timetable);
            get_table_info();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (table_id == -1)
            {
                MessageBox.Show("Please select a table to update.");
                return;
            }

            Timetable timetable = new Timetable
            {
                TimetableId = table_id,
                SubjectId = Convert.ToInt32(subject_combo.SelectedIndex),
                Timeslot = timeslot_txt.Text,
                RoomId = Convert.ToInt32(room_combo.SelectedIndex),
            };
            timetablecontroller.UpdateTimetable(timetable);
            get_table_info();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (table_id == -1)
            {
                MessageBox.Show("Please select a timetable to delete.");
                return;
            }
            timetablecontroller.DeleteTimetable(table_id );
            get_table_info();
        }
    }
}
