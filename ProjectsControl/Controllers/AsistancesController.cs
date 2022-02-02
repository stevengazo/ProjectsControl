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
    public class AsistancesController : Controller
    {
        private readonly DBProjectContext _context;

        public AsistancesController(DBProjectContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Received the list of daily asistances in the DB
        /// </summary>
        /// <param name="asistances">List of asistances </param>
        /// <returns>Same view</returns>
        [HttpPost] 
        public async Task<ActionResult> DailyCreate(List<Asistance> asistances )
        {
            try
            {
                if(asistances.Count !=0)
                {
                    foreach (Asistance asistance in asistances)
                    {
                        asistance.AsistanceId = Guid.NewGuid().ToString();
                    }
                    using (var context = _context)
                    {
                        await context.Asistances.AddRangeAsync(asistances);
                        await context.SaveChangesAsync();
                    }
                    ViewBag.ErrorMessage = "Asistencias Agregadas";
                    List<Asistance> sample1 = new List<Asistance>();
                    return View(sample1);
                }
                else
                {
                    ViewBag.ErrorMessage = "No hay asistencias registradas";    
                    ViewBag.ErrorMessage.Style = "btn-danger";
                    List<Asistance> sample1 = new List<Asistance>();
                    return View(sample1);
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                List<Asistance> sample1 = new List<Asistance>();
                return View(sample1);
            }
            
        }

        /// <summary>
        ///  Return the basic information for the Daily Asistences
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DailyCreate()
        {               
            //  List of Weeks registered in the DB
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId");
            //  List of employees in the DB
            var employees  = (from employee in _context.Employees select employee).Where(E=> E.Position.Equals("Ayudante") || E.Position.Equals("tecnico")).ToList();
            //  Lista de proyectos 
            ViewBag.Projects = (from proj in _context.Projects select proj).Where(P => P.IsOver != true).ToDictionary( P=>P.ProjectId, P=>P.ProjectName );
            //  Lista de asistencia del empleado y preparación básica
            List<Asistance> assistancesByPerson = new List<Asistance>();
            foreach (var employee in employees)
            {
                Asistance tmpAsistance = new Asistance()
                {
                    AsistanceId = Guid.NewGuid().ToString(),
                    Employee = employee,
                    EmployeeId = employee.EmployeeId,
                    DateOfBegin = DateTime.Today.AddHours(7),
                    DateOfEnd= DateTime.Today.AddHours(17)
                    
                };
                assistancesByPerson.Add(tmpAsistance);
            }
            ViewBag.ErrorMessage = "";
            //  Retorno de la vista                    
            return View(assistancesByPerson);
        }




        // GET: Asistances
        public async Task<IActionResult> Index()
        {
            var dBProjectContext = _context.Asistances.Include(a => a.Employee).Include(a => a.Project).Include(a => a.Week);
            return View(await dBProjectContext.ToListAsync());
        }

        // GET: Asistances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistance = await _context.Asistances
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .Include(a => a.Week)
                .FirstOrDefaultAsync(m => m.AsistanceId == id);
            if (asistance == null)
            {
                return NotFound();
            }

            return View(asistance);
        }

        // GET: Asistances/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ProjectName"] = new SelectList(_context.Employees, "ProjectName", "ProjectName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId");

            var aux = (from a in _context.Employees select a).ToList();
            var dicEmpl = new Dictionary<string, string>();
            foreach (var item in aux)
            {
                dicEmpl.Add(item.EmployeeId, item.Name);
            }

            ViewBag.ListOfEmployes = dicEmpl;

            
            
            var listProj = (from proj in _context.Projects select proj).Where(P => P.IsOver != true).ToList();
            var dicProj = new Dictionary<string, string>();
            foreach (var item in listProj)
            {
                dicProj.Add(item.ProjectId, item.ProjectName);
            }
            ViewBag.Projects = dicProj;
            return View();
        }

        public async Task<IActionResult> Search()
        {
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.Projects = (from proj in _context.Projects select proj).Where(P => P.IsOver == false).ToList();
            ViewBag.Weeks = _context.Week.ToList();            
            return View(new List<Asistance>());
        }

        // POST: Asistances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsistanceId,DateOfBegin,DateOfEnd,EmployeeId,ProjectId,WeekId")] Asistance asistance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", asistance.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", asistance.ProjectId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", asistance.WeekId);
            var aux = (from a in _context.Employees select a).ToList();
            var dicEmpl = new Dictionary<string, string>();
            foreach (var item in aux)
            {
                dicEmpl.Add(item.EmployeeId, item.Name);
            }

            ViewBag.ListOfEmployes = dicEmpl;

            var listProj = (from proj in _context.Projects select proj).Where(P => P.IsOver != true).ToList();
            var dicProj = new Dictionary<string, string>();
            foreach (var item in listProj)
            {
                dicProj.Add(item.ProjectId, item.ProjectName);
            }
            ViewBag.Projects = dicProj;
            return  View(asistance);
        }

        // GET: Asistances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistance = await _context.Asistances.FindAsync(id);
            if (asistance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", asistance.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", asistance.ProjectId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", asistance.WeekId);
            return View(asistance);
        }

        // POST: Asistances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AsistanceId,DateOfBegin,DateOfEnd,EmployeeId,ProjectId,WeekId")] Asistance asistance)
        {
            if (id != asistance.AsistanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistanceExists(asistance.AsistanceId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", asistance.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", asistance.ProjectId);
            ViewData["WeekId"] = new SelectList(_context.Set<Week>(), "WeekId", "WeekId", asistance.WeekId);
            return View(asistance);
        }

        // GET: Asistances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistance = await _context.Asistances
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .Include(a => a.Week)
                .FirstOrDefaultAsync(m => m.AsistanceId == id);
            if (asistance == null)
            {
                return NotFound();
            }

            return View(asistance);
        }

        // POST: Asistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var asistance = await _context.Asistances.FindAsync(id);
            _context.Asistances.Remove(asistance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistanceExists(string id)
        {
            return _context.Asistances.Any(e => e.AsistanceId == id);
        }
    }
}
