namespace ClinicaTurnos.Models
{
    public class DisponibilidadEquipo
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public required Equipo Equipo { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        
        // Para representar si el equipo está disponible
        public bool EstaDisponible { get; set; }
    }
}
