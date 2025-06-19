using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class RoomController
    {
       
        public RoomController()
        {
            
        }

        Room room;
        public RoomController(Room room)
        {
            this.room = room;
        }

        public async Task AddRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {
                

                string query = "INSERT INTO Room (Name, RoomType) VALUES (@name, @roomtype);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.Name);
                    cmd.Parameters.AddWithValue("@roomtype", room.RoomType);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Room>> ShowOutput()
        {
            var rooms = new List<Room>();

            using (var conn = DbConfic.GetConnection())
            {

                string query = "SELECT * FROM Room;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader =  cmd.ExecuteReader())
                    {
                        while ( reader.Read())
                        {
                            rooms.Add(new Room
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                RoomType = reader.GetString(2),
                            });
                        }
                    }
                }
            }

            return rooms;
        }

        public async Task<Room> GetRoomById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Room WHERE Id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if ( reader.Read())
                        {
                            return new Room
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                RoomType = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task UpdateRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {

                string query = "UPDATE Room SET Name = @name, RoomType = @roomtype WHERE Id = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", room.Name);
                    cmd.Parameters.AddWithValue("@roomtype", room.RoomType);
                    cmd.Parameters.AddWithValue("@id", room.Id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteRoom(Room room)
        {
            using (var conn = DbConfic.GetConnection())
            {

                await conn.OpenAsync();
                string query = "DELETE FROM Room WHERE Id = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", room.Id);
                     cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
