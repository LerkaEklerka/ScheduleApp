using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Commons.DTOModels
{
    public class LessonDTO
    {
        [Display(Name = "Предмет")]
        public string Subject { get; set; }

        [Display(Name = "Вчитель")]
        public string Teacher { get; set; }

        [Display(Name = "Група")]
        public string Group { get; set; }

        [Display(Name = "Кабінет")]
        public string Classroom { get; set; }
    }
}
