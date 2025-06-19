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
    public partial class StaffForm : Form
    {
        StaffController staffController=new StaffController();
        private int staff_id = -1;
        public StaffForm()
        {
            InitializeComponent();
            get_staff_info();
        }
        private void get_staff_info() 
        {
            dgv_staff.DataSource = null;
            dgv_staff.DataSource = staffController.ShowOutput();
            dgv_staff.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            name_txt.Text = string.Empty;
            address_txt.Text = string.Empty;
            email_txt.Text = string.Empty;
            staff_id = -1;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_txt.Text) || string.IsNullOrWhiteSpace(address_txt.Text))
            {
                MessageBox.Show("Please enter the name and address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Staff staff = new Staff
            {
                Name = name_txt.Text,
                Address = address_txt.Text,
                Email = email_txt.Text,
            };

            StaffController staffController = new StaffController(staff);

            get_staff_info();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            {
                if (dgv_staff.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a staff to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(name_txt.Text) || string.IsNullOrWhiteSpace(address_txt.Text))
                {
                    MessageBox.Show("Please enter the name and address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int staff_id = Convert.ToInt32(dgv_staff.SelectedRows[0].Cells["ID"].Value);

                Staff staff = new Staff
                {
                    Id = staff_id,
                    Name = name_txt.Text,
                    Address = address_txt.Text,
                    Email = email_txt.Text,
                };

                StaffController staffController = new StaffController(staff);
                staffController .UpdateStaff(staff);

                get_staff_info();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_staff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int staff_id = Convert.ToInt32(dgv_staff.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show("Are you sure want to delete the staff?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Staff staff = new Staff
                {
                    Id = staff_id
                };

                StaffController staffController = new StaffController(staff);
                staffController.DeleteStaff(staff);

                get_staff_info();
            }
        }

        private void dgv_staff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_staff.SelectedRows.Count > 0)
            {
                var row = dgv_staff.SelectedRows[0];
                var staff = (Staff)row.DataBoundItem;

                staff_id= staff.Id;
                name_txt.Text = staff.Name;
                address_txt.Text = staff.Address;
                email_txt.Text = staff.Email;
            }
            else
            {
                ClearInputs();
            }
        }
    }
}
