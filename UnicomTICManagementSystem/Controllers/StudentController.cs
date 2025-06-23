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
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@address", student.StudentAddress);
                    cmd.Parameters.AddWithValue("@stream", student.StudentStream);
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
                                StudentId = reader.GetInt32(0),
                                StudentName = reader.GetString(1),
                                StudentAddress = reader.GetString(2),
                                StudentStream = reader.GetString(3)
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
                                StudentId = reader.GetInt32(0),
                                StudentName = reader.GetString(1),
                                StudentAddress = reader.GetString(2),
                                StudentStream = reader.GetString(3)
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
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@address", student.StudentAddress);
                    cmd.Parameters.AddWithValue("@stream", student.StudentStream);
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
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@address", student.StudentAddress);
                    cmd.Parameters.AddWithValue("@stream", student.StudentStream);
                    cmd.Parameters.AddWithValue("@id", student.StudentId); 
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
                    cmd.Parameters.AddWithValue("@Id", student.StudentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}    

