using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScheduleApp.Data;
using ScheduleApp.Models;
using ScheduleApp.Constants;


namespace ScheduleApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public HomeController(
            ILogger<HomeController> _logger, 
            ApplicationDbContext _dbContext, 
            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            logger = _logger;
            dbContext = _dbContext;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            if (!signInManager.IsSignedIn(User))
            {
                return await Task.Run(() => View());
            }
                       
            User user = dbContext.CustomUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (user != null)
            {
                if (User.IsInRole("Студент"))
                {
                    return RedirectToAction(nameof(StudentHome), (DateTime.Today, user));
                }
                else if (User.IsInRole("Викладач"))
                {
                    return RedirectToAction(nameof(TeacherHome));
                }
                else if (User.IsInRole("Адміністратор"))
                {
                    return RedirectToAction(nameof(Manage));
                }
                else
                {
                    return RedirectToAction(nameof(ErrorAuth));
                }               
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }

        }

        public async Task<IActionResult> StudentHome(DateTime? date, User user)
        {
            var filterDate = date != null ? date : DateTime.Today;
            ViewData["FilterDate"] = filterDate;
            if (user.GroupId != null)
            {
                var applicationDbContext = dbContext.Lessons
                .Where(l => l.Date == filterDate)
                .Where(l => l.GroupId == user.GroupId)
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher);


                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var result = await Task.Run(() => new List<Lesson>());
                ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + ": You do not belong to any group. Ask an administrator to add you to your group list.";
                return View(result);
            }
        }

        public async Task<IActionResult> TeacherHome()
        {
            DateTime startAtMonday = DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);

            var teacherLessonsList = dbContext.Lessons
                .Where(l => l.Date >= startAtMonday)
                .OrderBy(l => l.Date)
                .ThenBy(l => l.Number)
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher);
            return View(await teacherLessonsList.ToListAsync());
        }

               public IActionResult Manage()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorAuth()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
             
    }
}
