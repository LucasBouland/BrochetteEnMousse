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
    public class MapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Maps.Include(m => m.Scenario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Maps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .Include(m => m.Scenario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Maps/Create
        public IActionResult Create()
        {
            ViewData["ScenarioID"] = new SelectList(_context.Scenarios, "ID", "ID");
            return View();
        }

        // POST: Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScenarioID,Name,Image,ID")] Map map)
        {
            if (ModelState.IsValid)
            {
                _context.Add(map);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScenarioID"] = new SelectList(_context.Scenarios, "ID", "ID", map.ScenarioID);
            return View(map);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Maps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Maps.FindAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            ViewData["ScenarioID"] = new SelectList(_context.Scenarios, "ID", "ID", map.ScenarioID);
            return View(map);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ScenarioID,Name,Image,ID")] Map map)
        {
            if (id != map.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(map);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapExists(map.ID))
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
            ViewData["ScenarioID"] = new SelectList(_context.Scenarios, "ID", "ID", map.ScenarioID);
            return View(map);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Maps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .Include(m => m.Scenario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var map = await _context.Maps.FindAsync(id);
            _context.Maps.Remove(map);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapExists(string id)
        {
            return _context.Maps.Any(e => e.ID == id);
        }
    }
}
