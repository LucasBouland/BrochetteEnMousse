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
    public class ScenariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScenariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Scenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> GetScenarios()
        {
            return await _context.Scenarios.ToListAsync();
        }

        // GET: api/Scenarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scenario>> GetScenario(string id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return scenario;
        }

        // PUT: api/Scenarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScenario(string id, Scenario scenario)
        {
            if (id != scenario.ID)
            {
                return BadRequest();
            }

            _context.Entry(scenario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioExists(id))
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

        // POST: api/Scenarios
        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            _context.Scenarios.Add(scenario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScenario", new { id = scenario.ID }, scenario);
        }

        // DELETE: api/Scenarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scenario>> DeleteScenario(string id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            _context.Scenarios.Remove(scenario);
            await _context.SaveChangesAsync();

            return scenario;
        }

        private bool ScenarioExists(string id)
        {
            return _context.Scenarios.Any(e => e.ID == id);
        }
    }
}
