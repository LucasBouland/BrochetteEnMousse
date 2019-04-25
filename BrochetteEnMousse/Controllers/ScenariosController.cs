using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;

namespace BrochetteEnMousse.Controllers
{
    public class ScenariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScenariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scenarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Scenarios.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Scenarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Scenarios/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Scenarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Name,Visibility,Content,ID")] Scenario scenario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scenario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", scenario.UserID);
            return View(scenario);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Scenarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", scenario.UserID);
            return View(scenario);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Scenarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,Name,Visibility,Content,ID")] Scenario scenario)
        {
            if (id != scenario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scenario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScenarioExists(scenario.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", scenario.UserID);
            return View(scenario);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Scenarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scenario = await _context.Scenarios
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scenario == null)
            {
                return NotFound();
            }

            return View(scenario);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Scenarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);
            _context.Scenarios.Remove(scenario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScenarioExists(string id)
        {
            return _context.Scenarios.Any(e => e.ID == id);
        }
    }
}
