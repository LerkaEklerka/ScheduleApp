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

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> TeacherHome(DateTime? newDate, int? filter)
        {
            //radio option
            ViewData["FilterOption"] = filter ?? 1;

            var teacherLessonsList = dbContext.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher);

            DateTime filterDate = newDate ?? DateTime.Today;
            ViewData["FilterDate"] = filterDate;

            var firstDayOfMonth = new DateTime(filterDate.Year, filterDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var datesList = new List<DateTime>();
            for (var dt = firstDayOfMonth; dt <= lastDayOfMonth; dt = dt.AddDays(1))
            {
                datesList.Add(dt);
            }
            ViewData["DatesList"] = datesList;

            var numbersList = new List<string>
            {
                "7:30 - 8:50", "9:00 - 10:20", "10:30 - 11:50", "12:10 - 13:30",
                "13:40 - 15:00", "15:10 - 16:30", "16:40 - 18:00", "18:10 - 19:00"
            };
            ViewData["NumbersList"] = numbersList;

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
