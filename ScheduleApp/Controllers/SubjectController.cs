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
    [Authorize(Roles = "Адміністратор")]
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                var existedSubject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Name == subject.Name);

                if (existedSubject == null)
                {
                    _context.Add(subject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + "Додати саме цей предмет неможливо. Предмет з такою назвою вже існує!";

                }
            }
            return View(subject);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,Name")] Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existedSubject = await _context.Subjects
               .FirstOrDefaultAsync(m => m.Name == subject.Name);

                if (existedSubject == null)
                {
                    try
                    {
                        _context.Update(subject);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubjectExists(subject.SubjectId))
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
                    ViewData[ScheduleConstants.ERROR_MESSAGE_KEY] = ScheduleConstants.ERROR_MESSAGE_PREFIX + "Змінити назву предмету неможливо. Предмет з такою назвою вже існує!";

                }
            }
            return View(subject);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
