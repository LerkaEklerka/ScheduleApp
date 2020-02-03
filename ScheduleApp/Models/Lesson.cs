using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string TeacherId { get; set; }
        public int GroupId { get; set; }
        public string ClassroomName { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartLesson { get; set; }
        public DateTime EndLesson { get; set; }
        public string Info { get; set; }
    }
}
