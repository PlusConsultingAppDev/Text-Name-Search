using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSearchController : ControllerBase
    {
        private readonly EmployeeSearchContext _context;

        public EmployeeSearchController(EmployeeSearchContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSearches
        [HttpGet]
        public IEnumerable<EmployeeSearch> GetEmployeeSearch()
        {
            return _context.EmployeeSearch;
        }

        // GET: api/EmployeeSearches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeSearch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeSearch = await _context.EmployeeSearch.FindAsync(id);

            if (employeeSearch == null)
            {
                return NotFound();
            }

            return Ok(employeeSearch);
        }

        // PUT: api/EmployeeSearches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSearch([FromRoute] int id, [FromBody] EmployeeSearch employeeSearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeSearch.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSearchExists(id))
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

        // POST: api/EmployeeSearches
        [HttpPost]
        public async Task<IActionResult> PostEmployeeSearch([FromBody] EmployeeSearch employeeSearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeSearch.Add(employeeSearch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSearch", new { id = employeeSearch.Id }, employeeSearch);
        }

        // DELETE: api/EmployeeSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeSearch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeSearch = await _context.EmployeeSearch.FindAsync(id);
            if (employeeSearch == null)
            {
                return NotFound();
            }

            _context.EmployeeSearch.Remove(employeeSearch);
            await _context.SaveChangesAsync();

            return Ok(employeeSearch);
        }

        private bool EmployeeSearchExists(int id)
        {
            return _context.EmployeeSearch.Any(e => e.Id == id);
        }
    }
}