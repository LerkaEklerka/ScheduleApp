﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Data;
using ScheduleApp.Models;
using ScheduleApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleApp.Controllers
{
    [Authorize(Roles = "Адміністратор")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomUsers.Include(u => u.Group).ToListAsync());
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id","Email","FirstName","LastName","GroupId")]User userForm)
        {
            if (id != userForm.Id)
            {
                return NotFound();
            }

            User user = await _userManager.FindByIdAsync(id);
            user.Email = userForm.Email;
            user.UserName = userForm.Email;
            user.FirstName = userForm.FirstName;
            user.LastName = userForm.LastName;
            user.GroupId = userForm.GroupId;

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            return View(user);
        }

        private bool UserExists(string id)
        {
            return _context.CustomUsers.Any(e => e.Id == id);
        }
    }
}
