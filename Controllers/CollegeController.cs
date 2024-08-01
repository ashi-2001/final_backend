using Final_Assessment.Data;
using Final_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 // Replace with your actual namespace

namespace Final_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CollegeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/College
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colleges>>> GetColleges()
        {
            return await _context.Colleges.ToListAsync();
        }

        // GET: api/College/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colleges>> GetCollege(int id)
        {
            var college = await _context.Colleges.FindAsync(id);

            if (college == null)
            {
                return NotFound();
            }

            return college;
        }

        // POST: api/College
        [HttpPost]
        public async Task<ActionResult<Colleges>> PostCollege(Colleges college)
        {
            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollege", new { id = college.CollegeId }, college);
        }

        // PUT: api/College/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollege(int id, Colleges college)
        {
            if (id != college.CollegeId)
            {
                return BadRequest();
            }

            _context.Entry(college).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
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

        // DELETE: api/College/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollege(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }

            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.CollegeId == id);
        }
    }
}
