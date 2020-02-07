using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Назва предмету")]
        public string Name { get; set; }

        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
