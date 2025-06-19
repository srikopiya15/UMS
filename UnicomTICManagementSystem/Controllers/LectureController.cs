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
    internal class LectureController
    {
        public LectureController(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Lecturer (Name, Address,Email) VALUES (@name, @address,@email);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.Name);
                    cmd.Parameters.AddWithValue("@address", lecture.Address);
                    cmd.Parameters.AddWithValue("@email", lecture.Email);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public LectureController()
        {

        }

        public List<Lecture> ShowOutput()
        {
            List<Lecture> lecture = new List<Lecture>();

            using (var conn = DbConfic.GetConnection())
            {
                string query = "SELECT * FROM Lecturer;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lecture.Add(new Lecture
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Email = reader.GetString(3)
                            });

                        }

                    }
                }
                return lecture;
            }
        }
        public Lecture GetLectureId(int Id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM Lecturer WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lecture
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Email = reader.GetString(3)
                            };
                        }
                    }

                }
            }
            return null;
        }
        public void AddLecture(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Lecturer(Name,Address,Email) VALUES(@name,@address,@email)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.Name);
                    cmd.Parameters.AddWithValue("@address", lecture.Address);
                    cmd.Parameters.AddWithValue("@email", lecture.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateLecture(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Lecturer SET Name = @name, Address = @address, Email = @email WHERE Id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.Name);
                    cmd.Parameters.AddWithValue("@address", lecture.Address);
                    cmd.Parameters.AddWithValue("@email", lecture.Email);
                    cmd.Parameters.AddWithValue("@id", lecture.Id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void DeleteLecture(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Lecturer WHERE ID=@id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", lecture.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
