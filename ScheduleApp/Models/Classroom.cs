using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Кабінет")]
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
