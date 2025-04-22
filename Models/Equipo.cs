using ClinicaTurnos.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicaTurnos.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [MaxLength(200)] 
        public string? Descripcion { get; set; } //campo opcional
        // Relación con Turnos
        //public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
