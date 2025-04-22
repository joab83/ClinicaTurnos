using System.ComponentModel.DataAnnotations;

namespace ClinicaTurnos.Models
{
    public class Profesional
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Especialidad { get; set; } = string.Empty;
        
        public bool Habilitado { get; set; } = true;

        // Relación con Turnos
        //public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
