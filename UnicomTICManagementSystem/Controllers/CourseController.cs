using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class CourseController
    {
        public async Task<List<Course>> GetAllCourseAsync()
        {
             List < Course > course = new List<Course>();
           
             using (var conn = DbConfic.GetConnection())
             {
                string query = @"SELECT * FROM Course";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))

                {

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            course.Add(new Course
                            {
                                courseId = reader.GetInt32(0),
                                CourseName = reader.GetString(1),
                                StartDate = reader.GetDateTime(2),
                                EndDate = reader.GetDateTime(3),
                            });

                        }

                    }
                }
             }
             return course;
         
        }
        public CourseController ()
        { 

        }
        public async Task AddAsync(Course course)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Course(Name, Startdate, Enddate) VALUES(@name,@startdate,@enddate);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@startdate", course.StartDate);
                    cmd.Parameters.AddWithValue("@enddate", course.EndDate);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }



        public async Task UpdateAsync(Course course)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Course SET Name = @name, Startdate = @startdate, Enddate = @enddate WHERE ID = @id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@startdate", course.StartDate);
                    cmd.Parameters.AddWithValue("@enddate", course.EndDate);
                    cmd.Parameters.AddWithValue("@id", course.courseId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Course WHERE ID=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        
    }
}
