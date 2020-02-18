﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Data;
using ScheduleApp.Models;
using ScheduleApp.Constants;


namespace ScheduleApp.Controllers
{
   
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lesson
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lesson/Details/5
        [Authorize(Roles = "Адміністратор,Викладач,Студент")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lesson/Create
        [Authorize(Roles = "Адміністратор")]
        public IActionResult Create()
        {
            PrepareLessonView();
            return View();
        }

        // POST: Lesson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Create([Bind("LessonId,Type,Number,Date,StartLesson,EndLesson,Info,SubjectId,GroupId,TeacherId,ClassroomId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                SetLessonTimes(lesson);

                var existedLesson = await _context.Lessons
                     .Where(m => m.Date == lesson.Date)
                     .Where(m => m.GroupId == lesson.GroupId)
                     .Where(m => m.Number == lesson.Number)
                     .FirstOrDefaultAsync();

                if (existedLesson == null)
                {
                    _context.Add(lesson);
                   await _context.SaveChangesAsync();
                   return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + "Додати заняття не можливо. У обраної групи заняття в заданий час вже існує.";
                }
            }

            PrepareLessonView();
            return View(lesson);

        }

        // GET: Lesson/Edit/5
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            PrepareLessonView();
            return View(lesson);
        }

        // POST: Lesson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,Type,Number,Date,StartLesson,EndLesson,Info,SubjectId,GroupId,TeacherId,ClassroomId")] Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SetLessonTimes(lesson);

                var existedLesson = await _context.Lessons
                     .Where(m => m.Date == lesson.Date)
                     .Where(m => m.GroupId == lesson.GroupId)
                     .Where(m => m.Number == lesson.Number)
                     .FirstOrDefaultAsync();

                if (existedLesson == null)
                {
                    try
                    {
                        _context.Update(lesson);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LessonExists(lesson.LessonId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + "Додати заняття не можливо. У обраної групи заняття в заданий час вже існує.";
                }
               
            }
            PrepareLessonView();
            return View(lesson);
        }

        // GET: Lesson/Delete/5
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Classroom)
                .Include(l => l.Group)
                .Include(l => l.Subject)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.LessonId == id);
        }

        private void PrepareLessonView()
        {
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "Name");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name");
            ViewData["TeacherId"] = new SelectList(_context.CustomUsers, "Id", "FullName");
        }
        private void SetLessonTimes(Lesson lesson)
        {
            if (lesson.Number == 0)
            {
                SetLessonTimeByNumbers(lesson, 7, 30, 8, 50);
            }
            else if (lesson.Number == 1)
            {
                SetLessonTimeByNumbers(lesson, 9, 0, 10, 20);
            }
            else if (lesson.Number == 2)
            {
                SetLessonTimeByNumbers(lesson, 10, 30, 11, 50);
            }
            else if (lesson.Number == 3)
            {
                SetLessonTimeByNumbers(lesson, 12, 10, 13, 30);
            }
            else if (lesson.Number == 4)
            {
                SetLessonTimeByNumbers(lesson, 13, 40, 15, 0);
            }
            else if (lesson.Number == 5)
            {
                SetLessonTimeByNumbers(lesson, 15, 10, 16, 30);
            }
            else if (lesson.Number == 6)
            {
                SetLessonTimeByNumbers(lesson, 16, 40, 18, 0);
            }
            else if (lesson.Number == 7)
            {
                SetLessonTimeByNumbers(lesson, 18, 10, 19, 0);
            }
            else
            {
                ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + "Such a pair does not exist. Try entering from 0 to 7.";

            }
        }
        private void SetLessonTimeByNumbers(Lesson lesson, int startH, int startM, int endH, int endM)
        {
            lesson.StartLesson = new DateTime(
                lesson.Date.Year,
                lesson.Date.Month,
                lesson.Date.Day,
                startH, startM, 0);

            lesson.EndLesson = new DateTime(
                lesson.Date.Year,
                lesson.Date.Month,
                lesson.Date.Day,
                endH, endM, 0);
        }
    }
}
