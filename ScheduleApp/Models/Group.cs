using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 2)]
        [Display(Name = "Назва групи")]
        public string Name { get; set; }

        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
        public virtual ICollection<User> Students { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
