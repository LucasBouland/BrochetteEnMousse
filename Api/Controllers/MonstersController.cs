using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MousseModels.Data;
using MousseModels.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonstersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonstersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Monsters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monster>>> GetMonsters()
        {
            return await _context.Monsters.ToListAsync();
        }

        // GET: api/Monsters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monster>> GetMonster(string id)
        {
            var monster = await _context.Monsters.FindAsync(id);

            if (monster == null)
            {
                return NotFound();
            }

            return monster;
        }

        // PUT: api/Monsters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonster(string id, Monster monster)
        {
            if (id != monster.ID)
            {
                return BadRequest();
            }

            _context.Entry(monster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Monsters
        [HttpPost]
        public async Task<ActionResult<Monster>> PostMonster(Monster monster)
        {
            _context.Monsters.Add(monster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonster", new { id = monster.ID }, monster);
        }

        // DELETE: api/Monsters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Monster>> DeleteMonster(string id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            _context.Monsters.Remove(monster);
            await _context.SaveChangesAsync();

            return monster;
        }

        private bool MonsterExists(string id)
        {
            return _context.Monsters.Any(e => e.ID == id);
        }
    }
}
