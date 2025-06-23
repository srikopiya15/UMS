using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class MarkController
    {
        public Mark GetMarkById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {


                string query = "SELECT * FROM Mark WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Mark
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                MarkObtained = Convert.ToInt32(reader["MarkObtained"]),
                                Examtype = reader["ExamType"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddMark(Mark mark)
        {
            using (var conn = DbConfic.GetConnection())
            {


                string query = @"INSERT INTO Mark (StudentID, SubjectID, MarkObtained, ExamType)
                                 VALUES (@studentid, @subjectid, @markobtained, @examtype)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentid", mark.StudentId);
                    cmd.Parameters.AddWithValue("@subjectid", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@markobtained", mark.MarkObtained);
                    cmd.Parameters.AddWithValue("@examtype", mark.Examtype);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    
        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();

            using (var conn = DbConfic.GetConnection())
            {
                

                string query = "SELECT * FROM Mark";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            StudentId = Convert.ToInt32(reader["StudentID"]),
                            SubjectId = Convert.ToInt32(reader["SubjectID"]),
                            MarkObtained = Convert.ToInt32(reader["MarkObtained"]),
                            Examtype = reader["ExamType"].ToString()
                        });
                    }
                }
            }

            return marks;
        }

        public void UpdateMark(Mark mark)
        {
            using (var conn = DbConfic.GetConnection())
            {
                

                string query = @"UPDATE Mark
                                 SET MarkObtained = @markobtained
                                 WHERE StudentID = @studentid AND SubjectID = @subjectid AND ExamType = @examtype";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@markobtained", mark.MarkObtained);
                    cmd.Parameters.AddWithValue("@studentid", mark.StudentId);
                    cmd.Parameters.AddWithValue("@subjectid", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@examtype", mark.Examtype);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMark(int studentId, string examType)
        {
            using (var conn = DbConfic.GetConnection())
            {
                

                string query = @"DELETE FROM Mark
                                 WHERE StudentID = @studentid AND ExamType = @examtype";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentid", studentId);
                    cmd.Parameters.AddWithValue("@examtype", examType);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

