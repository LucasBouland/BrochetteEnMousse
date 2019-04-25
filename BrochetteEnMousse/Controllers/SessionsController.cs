using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;

namespace BrochetteEnMousse.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public SessionsController(ApplicationDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sessions.Include(s => s.Campaign);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Campaign)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["CampaignID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampaignID,Name,Visibility,Description,ID")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignID"] = new SelectList(_context.Users, "Id", "Id", session.CampaignID);
            var user = await _userManager.GetUserAsync(User);
            var claims = await _userManager.GetClaimsAsync(user);
            bool isNotFound = true;
            foreach (var claim in claims)
            {
                if(claim == new Claim("isMJ", "True"))
                {
                    isNotFound = false;
                }
            }
            if (isNotFound)
            {
                await _userManager.AddClaimAsync(user, new Claim("isMJ", "True"));
            }
            return View(session);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["CampaignID"] = new SelectList(_context.Users, "Id", "Id", session.CampaignID);
            return View(session);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CampaignID,Name,Visibility,Description,ID")] Session session)
        {
            if (id != session.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.ID))
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
            ViewData["CampaignID"] = new SelectList(_context.Users, "Id", "Id", session.CampaignID);
            return View(session);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Campaign)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        [Authorize(Roles = "Admin,User")]
        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(string id)
        {
            return _context.Sessions.Any(e => e.ID == id);
        }
    }
}
