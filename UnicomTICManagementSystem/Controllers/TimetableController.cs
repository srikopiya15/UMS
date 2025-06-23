using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class TimetableController
    {
        public List<Timetable> ShowAllTimetable()
        {
            var timetableList = new List<Timetable>();

            using (var conn = DbConfic.GetConnection())
            {
              

                string query = "SELECT * FROM Timetable;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int TimetableId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        string TimeSlot = reader.IsDBNull(1) ? null : reader.GetString(1);
                        int SubjectId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        int RoomId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                        timetableList.Add(new Timetable
                        {
                            TimetableId = TimetableId,
                            Timeslot = TimeSlot,
                            SubjectId = SubjectId,
                            RoomId = RoomId
                        });
                    }
                }
            }

            return timetableList;
        }

        public Timetable GetTimetableById(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                
                string query = "SELECT * FROM Timetable WHERE TimetableId = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Timetable
                            {
                                TimetableId = reader.GetInt32(0),
                                Timeslot = reader.IsDBNull(1) ? null : reader.GetString(1),
                                SubjectId = reader.GetInt32(2),
                                RoomId = reader.GetInt32(3),
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddTimetable(Timetable timetable)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "INSERT INTO Timetable (SubjectID, TimeSlot, RoomID) VALUES (@subjectid, @slot, @roomid);";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@subjectid", timetable.SubjectId);
                    cmd.Parameters.AddWithValue("@slot", timetable.Timeslot);
                    cmd.Parameters.AddWithValue("@roomid", timetable.RoomId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTimetable(Timetable timetable)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "UPDATE Timetable SET SubjectID = @sub, TimeSlot = @slot, RoomID = @roomid WHERE TimetableId = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sub", timetable.SubjectId);
                    cmd.Parameters.AddWithValue("@slot", timetable.Timeslot);
                    cmd.Parameters.AddWithValue("@roomid", timetable.RoomId);
                    cmd.Parameters.AddWithValue("@id", timetable.TimetableId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTimetable(int id)
        {
            using (var conn = DbConfic.GetConnection())
            {
                string query = "DELETE FROM Timetable WHERE TimetableId = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

