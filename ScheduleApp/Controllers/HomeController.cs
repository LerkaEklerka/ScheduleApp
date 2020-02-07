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
            IEnumerable<Lesson> lessons = dbContext.Lessons;
            ViewBag.Lessons = lessons;
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
