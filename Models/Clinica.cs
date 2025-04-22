using System.ComponentModel.DataAnnotations;

namespace ClinicaTurnos.Models // O el namespace que estés usando
{
    public class Clinica
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Direccion { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Telefono { get; set; } = string.Empty;

        public bool Habilitado { get; set; } = true;

        // Relación con Turnos
        //public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
