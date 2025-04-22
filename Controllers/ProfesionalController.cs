using Microsoft.AspNetCore.Mvc;
using ClinicaTurnos.Models;
using ClinicaTurnos.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaTurnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionalController : ControllerBase
    {
        private readonly TurnosContext _context;

        public ProfesionalController(TurnosContext context)
        {
            _context = context;
        }

        // Método para obtener el listado de profesionales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetProfesionales()
        {
            // Obtiene la lista de profesionales desde la base de datos
            var profesionales = await _context.Profesionales.ToListAsync();

            // Si no hay profesionales, retorna un NotFound
            if (profesionales == null || !profesionales.Any())
            {
                return NotFound("No se encontraron profesionales.");
            }

            return Ok(profesionales);  // Devuelve los profesionales con código de estado 200 (OK)
        }
        [HttpPost]
        public async Task<ActionResult<Profesional>> CrearProfesional([FromBody] Profesional profesional)
        {
            // Verificar que el nombre y apellido no estén vacíos
            if (string.IsNullOrEmpty(profesional.Nombre))
            {
                return BadRequest("El nombre es obligatorio.");
            }

            // Agregar el profesional a la base de datos
            _context.Profesionales.Add(profesional);
            await _context.SaveChangesAsync();

            // Devolver la respuesta con el recurso creado
            return CreatedAtAction(nameof(GetProfesional), new { id = profesional.Id }, profesional);
        }

        // GET: api/profesionales/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesional>> GetProfesional(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);

            if (profesional == null)
            {
                return NotFound();
            }

            return profesional;
        }
     
        // PUT: api/profesional/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProfesional(int id, [FromBody] Profesional profesional)
        {
            if (id != profesional.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalExists(id))
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

        private bool ProfesionalExists(int id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }

    }
}
