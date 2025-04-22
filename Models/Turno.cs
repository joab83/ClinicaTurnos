using ClinicaTurnos.Models;

namespace ClinicaTurnos.Models
{
    public class Turno
            {
        public int Id { get; set; }

        // Relación con Profesional
        public int ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }

        // Relación con Clinica
        public int ClinicaId { get; set; }
        public Clinica? Clinica { get; set; }

        // Relación con Equipo
        public int EquipoId { get; set; }
        public Equipo? Equipo { get; set; }

        // Fecha y hora del turno
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Relación con Paciente
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
