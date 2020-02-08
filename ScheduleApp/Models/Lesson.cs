using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleApp.Models
{
    public enum LessonType
    {
        [Display(Name = "Лекція")]
        Lecture = 1,

        [Display(Name = "Практика")]
        Practise = 2,

        [Display(Name = "Семінар")]
        Seminar = 3,

        [Display(Name = "Не визначений")]
        NonSpecified = 4
    }
    public class Lesson
    {
        public int LessonId { get; set; }

        [Required]
        [Display(Name = "Тип заняття")]
        public LessonType Type { get; set; }

        [Required]
        [Range(0, 8)]
        [Display(Name = "Номер пари(не по змінам)")]
        public int Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "День заняття")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Початок заняття")]
        public DateTime StartLesson { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Кінець заняття")]
        public DateTime EndLesson { get; set; }

        [Display(Name = "Додаткова інформація")]
        public string Info { get; set; }

        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }
        [Display(Name = "Предмет")]
        public virtual Subject Subject { get; set; }

        [Display(Name = "Група")]
        public int GroupId { get; set; }
        [Display(Name = "Група")]
        public virtual Group Group { get; set; }

        [Display(Name = "Вчитель")]
        public string TeacherId { get; set; }
        [Display(Name = "Вчитель")]
        public virtual User Teacher { get; set; }

        [Display(Name = "Кабінет")]
        public int ClassroomId { get; set; }
        [Display(Name = "Кабінет")]
        public virtual Classroom Classroom { get; set; }
    }
}
