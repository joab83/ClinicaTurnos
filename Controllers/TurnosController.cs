using Microsoft.AspNetCore.Mvc;
using ClinicaTurnos.Models;
using ClinicaTurnos.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly TurnosContext _context;

        public TurnosController(TurnosContext context)
        {
            _context = context;
        }

        // POST: api/turnos
        [HttpPost]
        public async Task<ActionResult<Turno>> CrearTurno([FromBody] Turno turno)
        {
            // Validar si el Profesional está ocupado
            var turnoProfesional = await _context.Turnos
                .FirstOrDefaultAsync(t => 
                    t.ProfesionalId == turno.ProfesionalId 
                    && t.Fecha == turno.Fecha
                    && (t.HoraInicio < turno.HoraFin && t.HoraFin > turno.HoraInicio));

            if (turnoProfesional != null)
            {
                return BadRequest("El profesional ya está ocupado en la fecha y hora solicitadas.");
            }

            // Validar si el Equipo está ocupado
            var turnoEquipo = await _context.Turnos
                .FirstOrDefaultAsync(t => 
                    t.EquipoId == turno.EquipoId 
                    && t.Fecha == turno.Fecha
                    && (t.HoraInicio < turno.HoraFin && t.HoraFin > turno.HoraInicio));

            if (turnoEquipo != null)
            {
                return BadRequest("El equipo no está disponible en la fecha y hora solicitadas.");
            }

            // Validar si el Paciente ya tiene un turno en la misma fecha y hora
            var turnoPaciente = await _context.Turnos
                .FirstOrDefaultAsync(t => 
                    t.PacienteId == turno.PacienteId 
                    && t.Fecha == turno.Fecha
                    && (t.HoraInicio < turno.HoraFin && t.HoraFin > turno.HoraInicio));

            if (turnoPaciente != null)
            {
                return BadRequest("El paciente ya tiene un turno en la fecha y hora solicitadas.");
            }

            // Agregar el turno a la base de datos
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTurno), new { id = turno.Id }, turno);
        }


        // GET: api/turnos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Turno>> GetTurno(int id)
        {
            var turno = await _context.Turnos.Include(t => t.Paciente)
                                              .Include(t => t.Profesional)
                                              .Include(t => t.Clinica)
                                              .Include(t => t.Equipo)
                                              .FirstOrDefaultAsync(t => t.Id == id);

            if (turno == null)
            {
                return NotFound();
            }

            return Ok(turno);
        }

        // GET: api/turnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            var turnos = await _context.Turnos.Include(t => t.Paciente)
                                              .Include(t => t.Profesional)
                                              .Include(t => t.Clinica)
                                              .Include(t => t.Equipo)
                                              .ToListAsync();
            return Ok(turnos);
        }
    }
}
