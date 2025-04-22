using ClinicaTurnos.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicaTurnos.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? DNI { get; set; } // Documento de identidad
        
        [MaxLength(100)]
        public string? Telefono { get; set; }  // Nro Telefono
        // Relación con Turnos
        //public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
