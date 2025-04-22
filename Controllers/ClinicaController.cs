using Microsoft.AspNetCore.Mvc;
using ClinicaTurnos.Models;
using ClinicaTurnos.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly TurnosContext _context;

        public ClinicaController(TurnosContext context)
        {
            _context = context;
        }

        // GET: api/clinica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinica>>> GetClinicas()
        {
            var clinicas = await _context.Clinicas.ToListAsync();
            return Ok(clinicas);
        }

        // GET: api/clinica/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinica>> GetClinica(int id)
        {
            var clinica = await _context.Clinicas.FindAsync(id);

            if (clinica == null)
            {
                return NotFound();
            }

            return Ok(clinica);
        }

        // POST: api/clinica
        [HttpPost]
        public async Task<ActionResult<Clinica>> CrearClinica([FromBody] Clinica clinica)
        {
            _context.Clinicas.Add(clinica);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClinica), new { id = clinica.Id }, clinica);
        }

        // PUT: api/clinica/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarClinica(int id, [FromBody] Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return BadRequest();
            }

            _context.Entry(clinica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clinicas.Any(c => c.Id == id))
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

        // DELETE: api/clinica/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarClinica(int id)
        {
            var clinica = await _context.Clinicas.FindAsync(id);
            if (clinica == null)
            {
                return NotFound();
            }

            _context.Clinicas.Remove(clinica);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
