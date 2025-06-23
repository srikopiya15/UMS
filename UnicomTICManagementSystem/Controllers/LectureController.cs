using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class LectureController
    {
        public LectureController()
        { 

        }
        public LectureController(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Lecturer (Name,Address,Email) VALUES (@name,@address,@email);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.LecturerName);
                    cmd.Parameters.AddWithValue("@address", lecture.LecturerAddress);
                    cmd.Parameters.AddWithValue("@email", lecture.LecturerEmail);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Lecture> ShowOutput()
        {
            List<Lecture> lectures = new List<Lecture>();

            using (var conn = DbConfic.GetConnection())
            {

                string query = "SELECT * FROM Lecturer;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lectures.Add(new Lecture
                        {
                            LecturerId = reader.GetInt32(0),
                            LecturerName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            LecturerAddress = reader.IsDBNull(2) ? null : reader.GetString(2),
                            LecturerEmail = reader.IsDBNull(3) ? null : reader.GetString(3),
                        });
                    }
                }
            }

            return lectures;
        }

        public Lecture GetLectureById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Lecturer WHERE ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lecture
                            {
                                LecturerId = reader.GetInt32(0),
                                LecturerName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                LecturerAddress = reader.IsDBNull(2) ? null : reader.GetString(2),
                                LecturerEmail = reader.IsDBNull(3) ? null : reader.GetString(3),
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
             
                string query = "INSERT INTO Lecturer(Name, Address, Email) VALUES (@name, @address, @email);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.LecturerName);
                    cmd.Parameters.AddWithValue("@address", lecture.LecturerAddress);
                    cmd.Parameters.AddWithValue("@email", lecture.LecturerEmail);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLecture(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Lecturer SET Name = @name, Address = @address, Email = @email WHERE ID = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", lecture.LecturerName);
                    cmd.Parameters.AddWithValue("@address", lecture.LecturerAddress);
                    cmd.Parameters.AddWithValue("@email", lecture.LecturerEmail);
                    cmd.Parameters.AddWithValue("@id", lecture.LecturerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLecture(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
             

                string query = "DELETE FROM Lecturer WHERE ID = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

