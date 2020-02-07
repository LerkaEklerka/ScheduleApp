using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Data;
using ScheduleApp.Models;

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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lessons.Include(l => l.Classroom).Include(l => l.Group).Include(l => l.Subject).Include(l => l.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lesson/Details/5
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
        public IActionResult Create()
        {
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "Name");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name");
            ViewData["TeacherId"] = new SelectList(_context.CustomUsers, "Id", "Id");
            return View();
        }

        // POST: Lesson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,Type,Number,Date,StartLesson,EndLesson,Info,SubjectId,GroupId,TeacherId,ClassroomId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "Name", lesson.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", lesson.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.CustomUsers, "Id", "Id", lesson.TeacherId);
            return View(lesson);
        }

        // GET: Lesson/Edit/5
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
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "Name", lesson.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", lesson.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.CustomUsers, "Id", "Id", lesson.TeacherId);
            return View(lesson);
        }

        // POST: Lesson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,Type,Number,Date,StartLesson,EndLesson,Info,SubjectId,GroupId,TeacherId,ClassroomId")] Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "ClassroomId", "Name", lesson.ClassroomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", lesson.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", lesson.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.CustomUsers, "Id", "Id", lesson.TeacherId);
            return View(lesson);
        }

        // GET: Lesson/Delete/5
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
    }
}
