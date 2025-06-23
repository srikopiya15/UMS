using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class StaffController
    {
        public StaffController(Staff staff)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Staff (Name, Address,Email) VALUES (@name, @address,@email);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", staff.StaffName);
                    cmd.Parameters.AddWithValue("@address", staff.StaffAddress);
                    cmd.Parameters.AddWithValue("@email", staff.StaffEmail);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public StaffController()
        {

        }

        public List<Staff> ShowOutput()
        {
            List<Staff> staff = new List<Staff>();

            using (var conn = DbConfic.GetConnection())
            {
                string query = "SELECT * FROM Staff;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staff.Add(new Staff
                            {
                                StaffId = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                StaffAddress = reader.GetString(2),
                                StaffEmail = reader.GetString(3)
                            });

                        }

                    }
                }
                return staff;
            }
        }
        public Staff GetStaffId(int Id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM Staff WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Staff
                            {
                                StaffId = reader.GetInt32(0),
                                StaffName = reader.GetString(1),
                                StaffAddress = reader.GetString(2),
                                StaffEmail = reader.GetString(3)
                            };
                        }
                    }

                }
            }
            return null;
        }
        public void AddStaff(Staff staff)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Staff(Name,Address,Email) VALUES(@name,@address,@email)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", staff.StaffName);
                    cmd.Parameters.AddWithValue("@address", staff.StaffAddress);
                    cmd.Parameters.AddWithValue("@email", staff.StaffEmail);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStaff(Staff staff)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Staff SET Name = @name, Address = @address, Email = @email WHERE Id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", staff.StaffName);
                    cmd.Parameters.AddWithValue("@address", staff.StaffAddress);
                    cmd.Parameters.AddWithValue("@email", staff.StaffEmail);
                    cmd.Parameters.AddWithValue("@id", staff.StaffId);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void DeleteStaff(Staff staff)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Staff WHERE ID=@id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", staff.StaffId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
