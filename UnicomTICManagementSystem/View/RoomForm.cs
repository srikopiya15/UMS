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
    public partial class RoomForm : Form
    {
        private RoomController roomController=new RoomController();
        private int  room_id=-1;
        public RoomForm()
        {
            InitializeComponent();
           
        }
        private async Task get_room_info() 
        {
            dgv_room.DataSource = null;
            dgv_room.DataSource = await roomController.ShowOutput();
            dgv_room.ClearSelection();
            ClearInputs();
        }
        private void ClearInputs() 
        {
            name_txt.Text = string.Empty;
            type_combo.Text = string.Empty;
            room_id = -1;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_room.SelectedRows.Count > 0)
            {
                var room = (Room)dgv_room.SelectedRows[0].DataBoundItem;

                room_id = room.Id;
                name_txt.Text = room.Name;
                type_combo.Text = room.RoomType;
            }
            else
            {
                ClearInputs();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_txt.Text) || string.IsNullOrWhiteSpace(type_combo.Text))
            {
                MessageBox.Show("Please enter the name and roomtype.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Room room = new Room
            {
                Name = name_txt.Text,
                RoomType = type_combo.Text,
                
            };
            await roomController.AddRoom(room);
            await get_room_info();
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            if (room_id == -1)
            {
                MessageBox.Show("Please select a room to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Room room = new Room
            {
                Id = room_id,
                Name = name_txt.Text,
                RoomType = type_combo.Text,
            };

            await roomController.UpdateRoom(room);
            await get_room_info();

        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (room_id == -1)
            {
                MessageBox.Show("Please select a room to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the room?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Room room = new Room { Id = room_id };
                await roomController.DeleteRoom(room);
                await get_room_info();
            }
        }
    }
}
