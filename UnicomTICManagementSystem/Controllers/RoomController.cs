using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class RoomController
    {
        public void AddRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {
               
                string query = "INSERT INTO Room (Name, RoomType) VALUES (@name, @roomtype);";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@roomtype", room.RoomType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public  List<Room> ShowOutput()
        {
            List<Room> rooms = new List<Room>();

            using (var conn = DbConfic.GetConnection())
            {
             
                string query = "SELECT * FROM Room;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader =cmd.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        rooms.Add (new Room
                        {
                            RoomId = reader.GetInt32(0),
                            RoomName = reader.GetString(1),
                            RoomType = reader.GetString(2),
                        });
                    }
                }
            }

            return rooms;
        }

        public Room GetRoomById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
            
                using (var cmd = new SQLiteCommand("SELECT * FROM Room WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Room
                            {
                                RoomId = reader.GetInt32(0),
                                RoomName = reader.GetString(1),
                                RoomType = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {
                
                string query = "UPDATE Room SET Name = @name, RoomType = @roomtype WHERE Id = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@roomtype", room.RoomType);
                    cmd.Parameters.AddWithValue("@id", room.RoomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {
             
                string query = "DELETE FROM Room WHERE Id = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.RoomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

