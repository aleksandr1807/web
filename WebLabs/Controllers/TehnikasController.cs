using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TehnikasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TehnikasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tehnikas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tehnika>>> GetTehniks(int? group)
        {
            return await _context.Tehniks
                .Where(t=>!group.HasValue|| t.TehnikaGroupId.Equals(group.Value))
                
                ?.ToListAsync();
        }

        // GET: api/Tehnikas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tehnika>> GetTehnika(int id)
        {
            var tehnika = await _context.Tehniks.FindAsync(id);

            if (tehnika == null)
            {
                return NotFound();
            }

            return tehnika;
        }

        // PUT: api/Tehnikas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTehnika(int id, Tehnika tehnika)
        {
            if (id != tehnika.TehnikaId)
            {
                return BadRequest();
            }

            _context.Entry(tehnika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehnikaExists(id))
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

        // POST: api/Tehnikas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tehnika>> PostTehnika(Tehnika tehnika)
        {
            _context.Tehniks.Add(tehnika);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTehnika", new { id = tehnika.TehnikaId }, tehnika);
        }

        // DELETE: api/Tehnikas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tehnika>> DeleteTehnika(int id)
        {
            var tehnika = await _context.Tehniks.FindAsync(id);
            if (tehnika == null)
            {
                return NotFound();
            }

            _context.Tehniks.Remove(tehnika);
            await _context.SaveChangesAsync();

            return tehnika;
        }

        private bool TehnikaExists(int id)
        {
            return _context.Tehniks.Any(e => e.TehnikaId == id);
        }
    }
}
