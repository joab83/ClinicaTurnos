namespace ClinicaTurnos.Models
{
    public class DisponibilidadProfesional
    {
        public int Id { get; set; }
        public int ProfesionalId { get; set; }
        public required Profesional Profesional { get; set; }

        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        
        // Para representar si está disponible o no
        public bool EstaDisponible { get; set; }
    }
}
