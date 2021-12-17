using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class interventionController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public interventionController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/intervention
        [HttpGet]
        public async Task<ActionResult<IEnumerable<interventions>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET: api/intervention/5
        [HttpGet("{id}")]
        public async Task<ActionResult<interventions>> Getinterventions(long id)
        {
            var interventions = await _context.interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }
        // GET: api/intervention/pending
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<interventions>>> GetinterventionsPending()
        {
            var inter = await _context.interventions.Where(intervention => intervention.status == "Pending" && intervention.started_at == null).ToListAsync();

            return inter;
        }

        // PUT: api/intervention/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinterventions(long id, interventions interventions)
        {
            if (id != interventions.id)
            {
                return BadRequest();
            }

            _context.Entry(interventions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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
        // PUT: api/intervention/5/inProgress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/inProgress")]
        public async Task<IActionResult> PutinterventionsInProgress(long id)
        {
            var interventions = await Intervention(id);
            interventions.status = "InProgress";
            interventions.started_at = DateTime.Now;


            // _context.Entry(inter).State = EntityState.Detached;
            _context.Entry(interventions).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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

        // PUT: api/intervention/5/completed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/completed")]
        public async Task<IActionResult> PutinterventionsCompleted(long id)
        {
            var interventions = await Intervention(id);
            interventions.status = "Completed";
            interventions.result = "Success";
            interventions.ended_at = DateTime.Now;


            // _context.Entry(inter).State = EntityState.Detached;
            _context.Entry(interventions).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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
        // POST: api/intervention
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<interventions>> Postinterventions(interventions interventions)
        {
            // Create New Intervention
            _context.interventions.Add(interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinterventions", new { id = interventions.id }, interventions);
        }

        // DELETE: api/intervention/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinterventions(long id)
        {
            var interventions = await _context.interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool interventionsExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }

        private async Task<interventions> Intervention(long id)
        {
            return await _context.interventions.FindAsync(id);
        }
    }
}
