using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Models
{
    internal class Timetable
    {
        public int  TimetableId { get; set; }    
        public string Timeslot { get; set; }
        public int SubjectId { get; set; }
        public int RoomId  { get; set; }

    }
}
