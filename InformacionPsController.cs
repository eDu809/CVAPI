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
    public class InformacionPsController : ControllerBase
    {
        private readonly CVContext _context;

        public InformacionPsController(CVContext context)
        {
            _context = context;
        }

        // GET: api/InformacionPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformacionP>>> GetInformacionP()
        {
            return await _context.InformacionP.ToListAsync();
        }

        // GET: api/InformacionPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformacionP>> GetInformacionP(int id)
        {
            var informacionP = await _context.InformacionP.FindAsync(id);

            if (informacionP == null)
            {
                return NotFound();
            }

            return informacionP;
        }

        // PUT: api/InformacionPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformacionP(int id, InformacionP informacionP)
        {
            if (id != informacionP.Id_Persona)
            {
                return BadRequest();
            }

            _context.Entry(informacionP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacionPExists(id))
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

        // POST: api/InformacionPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformacionP>> PostInformacionP(InformacionP informacionP)
        {
            _context.InformacionP.Add(informacionP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformacionP", new { id = informacionP.Id_Persona }, informacionP);
        }

        // DELETE: api/InformacionPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformacionP(int id)
        {
            var informacionP = await _context.InformacionP.FindAsync(id);
            if (informacionP == null)
            {
                return NotFound();
            }

            _context.InformacionP.Remove(informacionP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformacionPExists(int id)
        {
            return _context.InformacionP.Any(e => e.Id_Persona == id);
        }
    }
}
