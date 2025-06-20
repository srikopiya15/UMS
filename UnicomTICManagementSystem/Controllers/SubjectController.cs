using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class SubjectController
    {
        public List<Subject> ShowAllSubjects()
        {
            var subjects = new List<Subject>();

            using (var conn = DbConfic.GetConnection())
            {
                
                string query = "SELECT * FROM Subject;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectId = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID=reader.GetString(2),
                        });
                    }
                }
            }

            return subjects;
            
        }

        public Subject GetSubjectById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
               
                string query = "SELECT * FROM Subject WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                SubjectId = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseID = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddSubject(Subject subject)
        {
            using (var conn = DbConfic.GetConnection())
            {
               
                string query = "INSERT INTO Subject (Name, CourseID) VALUES (@name, @courseId);";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var conn = DbConfic.GetConnection())
            {
                
                string query = "UPDATE Subject SET Name = @name, CourseID = @courseId WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                    cmd.Parameters.AddWithValue("@id", subject.SubjectId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (var conn = DbConfic.GetConnection())
            {
               
                string query = "DELETE FROM Subject WHERE ID = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
