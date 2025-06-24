using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
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
        public LectureController()
        {

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
                            LecturerName = reader.GetString(1),
                            LecturerAddress = reader.GetString(2),
                            LecturerEmail = reader.GetString(3),
                        });
                    }
                }
            }

            return lectures;
        }

        public Lecture GetLectureById(int Id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Lecturer WHERE ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lecture
                            {
                                LecturerId = reader.GetInt32(0),
                                LecturerName = reader.GetString(1),
                                LecturerAddress = reader.GetString(2),
                                LecturerEmail = reader.GetString(3),
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

        public void DeleteLecture(Lecture lecture)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Lecturer WHERE ID = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id",lecture. LecturerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

