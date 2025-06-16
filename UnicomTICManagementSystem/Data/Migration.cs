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
                             
                                  CREATE TABLE IF NOT EXISTS Student(ID INTEGER PRIMARY KEY AUTOINCREMENT ,Name TEXT,Address STRING,Stream STRING);

                                  CREATE TABLE IF NOT EXISTS User(ID INTEGER PRIMARY KEY AUTOINCREMENT ,Role TEXT,Name TEXT,Password STRING);

                                  CREATE TABLE IF NOT EXISTS Session(ID INTEGER PRIMARY KEY AUTOINCREMENT ,Name TEXT NOT NULL);

                                  CREATE TABLE IF NOT EXISTS Timetable(ID INTEGER PRIMARY KEY AUTOINCREMENT ,TimeSlot TEXT,Subjectname TEXT NOT NULL);

                                ";
                using (SQLiteCommand cmd = new SQLiteCommand(query,conn)) 
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
   }
}
