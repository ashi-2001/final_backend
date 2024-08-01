

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
        public class CourseController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public CourseController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Course
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Courses>>> GetCourses()
            {
                return await _context.Courses.ToListAsync();
            }

            // GET: api/Course/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Courses>> GetCourse(int id)
            {
                var course = await _context.Courses.FindAsync(id);

                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }

            // POST: api/Course
            [HttpPost]
            public async Task<ActionResult<Courses>> PostCourse(Courses course)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
            }

            // PUT: api/Course/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCourse(int id, Courses course)
            {
                if (id != course.CourseId)
                {
                    return BadRequest();
                }

                _context.Entry(course).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(id))
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

            // DELETE: api/Course/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCourse(int id)
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CourseExists(int id)
            {
                return _context.Courses.Any(e => e.CourseId == id);
            }
        }
    }


