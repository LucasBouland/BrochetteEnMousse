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
    public class MonstersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonstersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monsters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monsters.ToListAsync());
        }

        // GET: Monsters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Monsters/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Monsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ID")] Monster monster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Monsters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Monsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,ID")] Monster monster)
        {
            if (id != monster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.ID))
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
            return View(monster);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Monsters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            _context.Monsters.Remove(monster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(string id)
        {
            return _context.Monsters.Any(e => e.ID == id);
        }
    }
}
