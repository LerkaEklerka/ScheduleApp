using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleApp.Models
{
    public enum LessonType
    {
        [Display(Name = "Лекція")]
        Lecture,

        [Display(Name = "Практика")]
        Practise,

        [Display(Name = "Семінар")]
        Seminar,

        [Display(Name = "Не визначений")]
        NonSpecified
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

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string TeacherId { get; set; }
        public virtual User Teacher { get; set; }

        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
