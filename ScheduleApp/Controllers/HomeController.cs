using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScheduleApp.Commons.DTOModels;
using ScheduleApp.Data;
using ScheduleApp.Models;

namespace ScheduleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> _logger, ApplicationDbContext _dbContext, UserManager<User> _userManager)
        {
            logger = _logger;
            dbContext = _dbContext;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<LessonDTO> lessonDTOList = mapToDTOList(dbContext.Lessons);
            ViewBag.Lessons = lessonDTOList;
            return View();
        }

        private List<LessonDTO> mapToDTOList(DbSet<Lesson> lessons)
        {
            List<LessonDTO> lessonDTOList = new List<LessonDTO>();

            foreach (Lesson lesson in lessons)
            {
                var user = userManager.Users.FirstOrDefault(u => u.Id == lesson.TeacherId);

                LessonDTO dto = new LessonDTO
                {
                    Classroom = dbContext.Classrooms.Find(lesson.ClassroomId).Name,
                    Group = dbContext.Groups.Find(lesson.GroupId).Name,
                    Subject = dbContext.Subjects.Find(lesson.SubjectId).Name,
                    Teacher = user != null ? user.UserName : ""
                };

                lessonDTOList.Add(dto);
            }
            return lessonDTOList;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
