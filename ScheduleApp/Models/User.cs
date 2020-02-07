using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
