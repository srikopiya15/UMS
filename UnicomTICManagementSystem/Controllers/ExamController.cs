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
    internal class ExamController
    {
        public List<Exam> ShowAllExam()
        {
            var exam = new List<Exam>();

            using (var conn = DbConfic.GetConnection())
            {

                string query = "SELECT * FROM Exam;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam.Add(new Exam
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            SubjectId = reader.GetString(2),
                        });
                    }
                }
            }

            return exam;

        }

        public Exam GetExamById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {

                string query = "SELECT * FROM Exam WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Exam
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SubjectId = reader.GetString(2),
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddExam(Exam exam)
        {
            using (var conn = DbConfic.GetConnection())
            {

                string query = "INSERT INTO Exam (Name, SubjectID) VALUES (@name, @subjectid);";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", exam.Name);
                    cmd.Parameters.AddWithValue("@subjectid", exam.SubjectId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateExam(Exam exam)
        {
            using (var conn = DbConfic.GetConnection())
            {

                string query = "UPDATE Exam SET Name = @name, SubjectID = @subjectId WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", exam.Name);
                    cmd.Parameters.AddWithValue("@subjectId", exam.SubjectId);
                    cmd.Parameters.AddWithValue("@id", exam.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExam(int Id)
        {
            using (var conn = DbConfic.GetConnection())
            {

                string query = "DELETE FROM Exam WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id",Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

