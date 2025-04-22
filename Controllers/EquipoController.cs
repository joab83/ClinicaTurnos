using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaTurnos.Data;
using ClinicaTurnos.Models;

namespace ClinicaTurnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoController : ControllerBase
    {
        private readonly TurnosContext _context;

        // Constructor
        public EquipoController(TurnosContext context)
        {
            _context = context;
        }

        // GET: api/equipo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> ObtenerEquipos()
        {
            // Obtener todos los equipos de la base de datos
            var equipos = await _context.Equipos.ToListAsync();
            return Ok(equipos);  // Devuelve la lista de equipos
        }

        // POST: api/equipo
        [HttpPost]
        public async Task<ActionResult<Equipo>> CrearEquipo([FromBody] Equipo equipo)
        {
            if (equipo == null)
            {
                return BadRequest("El equipo no puede ser nulo.");
            }

            // Agregar el nuevo equipo a la base de datos
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerEquipos), new { id = equipo.Id }, equipo);  // Devuelve el equipo creado
        }

        // GET: api/equipo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> ObtenerEquipo(int id)
        {
            // Buscar el equipo por su Id
            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();  // Si no existe, devuelve 404 Not Found
            }

            return Ok(equipo);  // Devuelve el equipo encontrado
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEquipo(int id, [FromBody] Equipo equipoActualizado)
        {
            if (id != equipoActualizado.Id)
            {
                return BadRequest("El ID del equipo no coincide con el ID de la ruta.");
            }

            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound("Equipo no encontrado.");
            }

            // Actualizar propiedades
            equipo.Nombre = equipoActualizado.Nombre;
            equipo.Descripcion = equipoActualizado.Descripcion;
            // Agregá cualquier otra propiedad que tenga tu modelo

            await _context.SaveChangesAsync();

            return NoContent(); // O return Ok(equipo) si querés devolver el objeto actualizado
        }

    }
}
