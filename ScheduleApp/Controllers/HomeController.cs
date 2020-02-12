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

namespace ScheduleApp.Controllers
{
    [RequireHttps]
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

        public async Task<IActionResult> Index(DateTime? date)
        {
            var filterDate = date != null ? date : DateTime.Today;
            //todo
            var applicationDbContext = dbContext.Lessons
                .Where(l => l.Date == filterDate)
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher);

            ViewData["FilterDate"] = filterDate;
            return View(await applicationDbContext.ToListAsync());
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
    }
}
