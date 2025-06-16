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
    internal class StudentController
    {
        public StudentController(Student student)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Student (Name,Address,Stream) VALUES (@name,@address,@stream);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@address", student.Address);
                    cmd.Parameters.AddWithValue("@stream", student.Stream);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public StudentController()
        {

        }

        public List<Student> ShowOutput()
        {
            List<Student> students = new List<Student>();

            using (var conn = DbConfic.GetConnection())
            {
                string query = "SELECT * FROM Student;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Stream = reader.GetString(3)
                            });

                        }

                    }
                }
                return students;
            }
        }
        public Student GetStudentId(int Id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM Student WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Stream = reader.GetString(3)
                            };
                        }
                    }

                }
            }
            return null;
        }
        public void AddStudent(Student student)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Student(name,address,stream) VALUES(@Name,@Address,@Stream)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@address", student.Address);
                    cmd.Parameters.AddWithValue("@stream", student.Stream);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStudent( Student student )
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Student SET name = @name, address = @address, stream = @stream WHERE id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@address", student.Address);
                    cmd.Parameters.AddWithValue("@stream", student.Stream);
                    cmd.Parameters.AddWithValue("@id", student.Id); 
                    cmd.ExecuteNonQuery();
                }

            }
        }
        
        public void DeleteStudent(Student student)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Student WHERE ID=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}    

