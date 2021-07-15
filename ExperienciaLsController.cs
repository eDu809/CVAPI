using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVAPI.Context;
using CVAPI.Models;

namespace CVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaLsController : ControllerBase
    {
        private readonly CVContext _context;

        public ExperienciaLsController(CVContext context)
        {
            _context = context;
        }

        // GET: api/ExperienciaLs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienciaL>>> GetExperienciaL()
        {
            return await _context.ExperienciaL.ToListAsync();
        }

        // GET: api/ExperienciaLs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienciaL>> GetExperienciaL(int id)
        {
            var experienciaL = await _context.ExperienciaL.FindAsync(id);

            if (experienciaL == null)
            {
                return NotFound();
            }

            return experienciaL;
        }

        // PUT: api/ExperienciaLs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienciaL(int id, ExperienciaL experienciaL)
        {
            if (id != experienciaL.Id_Experiencia)
            {
                return BadRequest();
            }

            _context.Entry(experienciaL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaLExists(id))
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

        // POST: api/ExperienciaLs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExperienciaL>> PostExperienciaL(ExperienciaL experienciaL)
        {
            _context.ExperienciaL.Add(experienciaL);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienciaL", new { id = experienciaL.Id_Experiencia }, experienciaL);
        }

        // DELETE: api/ExperienciaLs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienciaL(int id)
        {
            var experienciaL = await _context.ExperienciaL.FindAsync(id);
            if (experienciaL == null)
            {
                return NotFound();
            }

            _context.ExperienciaL.Remove(experienciaL);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienciaLExists(int id)
        {
            return _context.ExperienciaL.Any(e => e.Id_Experiencia == id);
        }
    }
}
