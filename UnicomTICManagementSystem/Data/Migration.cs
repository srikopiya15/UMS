using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Data
{
    internal class Migration
    {
        public void Create_Table() 
        {
            using(var conn= DbConfic.GetConnection()) 
            {
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

                        CREATE TABLE IF NOT EXISTS Session (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL
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
                        ";

                using (SQLiteCommand cmd = new SQLiteCommand(query,conn)) 
                {
                    cmd.ExecuteNonQueryAsync();
                }
            }
        }
   }
}
