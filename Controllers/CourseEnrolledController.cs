
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
        public class CourseEnrolledController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public CourseEnrolledController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/CourseEnrolled
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CoursesEnrolled>>> GetCoursesEnrolled()
            {
                return await _context.CoursesEnrolled.ToListAsync();
            }

            // GET: api/CourseEnrolled/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CoursesEnrolled>> GetCourseEnrolled(int id)
            {
                var courseEnrolled = await _context.CoursesEnrolled.FindAsync(id);

                if (courseEnrolled == null)
                {
                    return NotFound();
                }

                return courseEnrolled;
            }

            // POST: api/CourseEnrolled
            [HttpPost]
            public async Task<ActionResult<CoursesEnrolled>> PostCourseEnrolled(CoursesEnrolled courseEnrolled)
            {
                _context.CoursesEnrolled.Add(courseEnrolled);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCourseEnrolled", new { id = courseEnrolled.CourseEnrolledId }, courseEnrolled);
            }

            // PUT: api/CourseEnrolled/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCourseEnrolled(int id, CoursesEnrolled courseEnrolled)
            {
                if (id != courseEnrolled.CourseEnrolledId)
                {
                    return BadRequest();
                }

                _context.Entry(courseEnrolled).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseEnrolledExists(id))
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

            // DELETE: api/CourseEnrolled/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCourseEnrolled(int id)
            {
                var courseEnrolled = await _context.CoursesEnrolled.FindAsync(id);
                if (courseEnrolled == null)
                {
                    return NotFound();
                }

                _context.CoursesEnrolled.Remove(courseEnrolled);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CourseEnrolledExists(int id)
            {
                return _context.CoursesEnrolled.Any(e => e.CourseEnrolledId == id);
            }
        }
    }


