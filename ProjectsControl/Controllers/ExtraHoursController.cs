﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectsControl.Models;

namespace ProjectsControl.Controllers
{
    public class ExtraHoursController : Controller
    {
        private readonly DBProjectContext _context;

        public ExtraHoursController(DBProjectContext context)
        {
            _context = context;
        }

        // GET: ExtraHours
        public async Task<IActionResult> Index()
        {
            var dBProjectContext = _context.ExtraHours.Include(e => e.Asistance).Include(e => e.Employee).Include(e => e.Week);
            return View(await dBProjectContext.ToListAsync());
        }

        // GET: ExtraHours/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraHour = await _context.ExtraHours
                .Include(e => e.Asistance)
                .Include(e => e.Employee)
                .Include(e => e.Week)
                .FirstOrDefaultAsync(m => m.ExtraHourId == id);
            if (extraHour == null)
            {
                return NotFound();
            }

            return View(extraHour);
        }

        // GET: ExtraHours/Create
        public IActionResult Create()
        {
            ViewData["AsistanceId"] = new SelectList(_context.Asistances, "AsistanceId", "AsistanceId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId");
            return View();
        }

        // POST: ExtraHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExtraHourId,BeginTime,EndTime,TypeOfHour,Reason,Notes,IsPaid,EmployeeId,AsistanceId,WeekId")] ExtraHour extraHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extraHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsistanceId"] = new SelectList(_context.Asistances, "AsistanceId", "AsistanceId", extraHour.AsistanceId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", extraHour.EmployeeId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", extraHour.WeekId);
            return View(extraHour);
        }

        // GET: ExtraHours/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraHour = await _context.ExtraHours.FindAsync(id);
            if (extraHour == null)
            {
                return NotFound();
            }
            ViewData["AsistanceId"] = new SelectList(_context.Asistances, "AsistanceId", "AsistanceId", extraHour.AsistanceId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", extraHour.EmployeeId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", extraHour.WeekId);
            return View(extraHour);
        }

        // POST: ExtraHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ExtraHourId,BeginTime,EndTime,TypeOfHour,Reason,Notes,IsPaid,EmployeeId,AsistanceId,WeekId")] ExtraHour extraHour)
        {
            if (id != extraHour.ExtraHourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extraHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraHourExists(extraHour.ExtraHourId))
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
            ViewData["AsistanceId"] = new SelectList(_context.Asistances, "AsistanceId", "AsistanceId", extraHour.AsistanceId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", extraHour.EmployeeId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", extraHour.WeekId);
            return View(extraHour);
        }

        // GET: ExtraHours/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraHour = await _context.ExtraHours
                .Include(e => e.Asistance)
                .Include(e => e.Employee)
                .Include(e => e.Week)
                .FirstOrDefaultAsync(m => m.ExtraHourId == id);
            if (extraHour == null)
            {
                return NotFound();
            }

            return View(extraHour);
        }

        // POST: ExtraHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var extraHour = await _context.ExtraHours.FindAsync(id);
            _context.ExtraHours.Remove(extraHour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraHourExists(string id)
        {
            return _context.ExtraHours.Any(e => e.ExtraHourId == id);
        }
    }
}
