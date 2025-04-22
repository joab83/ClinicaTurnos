using Microsoft.EntityFrameworkCore;
using ClinicaTurnos.Models;

namespace ClinicaTurnos.Data
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options) { }

        // Agregar los DbSet para cada tabla
        public required DbSet<Clinica> Clinicas { get; set; }
        public required DbSet<Profesional> Profesionales { get; set; }
        public required DbSet<Equipo> Equipos { get; set; }
        public required DbSet<Paciente> Pacientes { get; set; }
        public required DbSet<Turno> Turnos { get; set; }
        public required DbSet<DisponibilidadProfesional> DisponibilidadProfesionales { get; set; }
        public required DbSet<DisponibilidadEquipo> DisponibilidadEquipos { get; set; }

    }
}
