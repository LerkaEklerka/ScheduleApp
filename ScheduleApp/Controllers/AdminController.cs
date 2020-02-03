using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleApp.Commons.DTOModels;
using ScheduleApp.Data;
using ScheduleApp.Models;

namespace ScheduleApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;

        public AdminController(ILogger<AdminController> _logger, ApplicationDbContext _dbContext, UserManager<User> _userManager)
        {
            logger = _logger;
            dbContext = _dbContext;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLesson(LessonDTO lessonDTO)
        {
            if (lessonDTO != null)
            {
                Subject subject = new Subject { Name = lessonDTO.Subject };
                dbContext.Subjects.Add(subject);

                Group group = new Group { Name = lessonDTO.Group };
                dbContext.Groups.Add(group);

                dbContext.SaveChanges();

                Lesson newLesson = new Lesson
                {
                    SubjectId = subject.Id,
                    GroupId = group.Id,
                    ClassroomName = lessonDTO.Classroom,
                    TeacherId = userManager.GetUserId(User)
                };

                dbContext.Lessons.Add(newLesson);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
