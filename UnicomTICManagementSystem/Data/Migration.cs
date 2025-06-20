using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Data
{
    internal class Migration
    {
        public async void Create_Table()
        {
            using (var conn = DbConfic.GetConnection())
            {
               

                string dropQuery = @"
                    DROP TABLE IF EXISTS Room;
                    DROP TABLE IF EXISTS Subject;
                ";

                using (var dropCmd = new SQLiteCommand(dropQuery, conn))
                {
                    await dropCmd.ExecuteNonQueryAsync();
                }

                string query = @"
                    CREATE TABLE IF NOT EXISTS Student (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Address TEXT,
                        Stream TEXT
                    );

                    CREATE TABLE IF NOT EXISTS User (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Role TEXT,
                        Name TEXT,
                        Password TEXT
                    );


                    CREATE TABLE IF NOT EXISTS Timetable (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TimeSlot TEXT,
                        SubjectName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Course (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        StartDate TEXT,
                        EndDate TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Lecturer (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Address TEXT,
                        Email TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Subject (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        CourseID INTEGER,
                        FOREIGN KEY (CourseID) REFERENCES Course(ID)
                    );

                    CREATE TABLE IF NOT EXISTS Staff (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Address TEXT,
                        Email TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Mark (
                        StudentID INTEGER,
                        SubjectID INTEGER,
                        MarkObtained INTEGER,
                        ExamType TEXT,
                        PRIMARY KEY (StudentID, ExamType),
                        FOREIGN KEY (StudentID) REFERENCES Student(ID),
                        FOREIGN KEY (SubjectID) REFERENCES Subject(ID)
                    );

                    CREATE TABLE IF NOT EXISTS Room (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        RoomType TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Exam (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        SubjectID INTEGER,
                        FOREIGN KEY (SubjectID) REFERENCES Subject(ID)
                    );
                ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
