using System.ComponentModel.DataAnnotations;

namespace Registro_Optativas.Modelos
{
    public class Materia
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "El 'Nombre' de la materia es requerida.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El 'Máximo de Lugares' es requerido.")]
        [StringLength(30, ErrorMessage = "Máximo 30 lugares por materia.")]
        public string? MaxLugares { get; set; }
        [Required(ErrorMessage = "El 'Aula' es requerida.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Aula { get; set; }
        [Required(ErrorMessage = "La 'Descripción' de la materia es requerida.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string? Descripcion { get; set; }
        // Propiedad de navegación EF.
        virtual public ICollection<Estudiante>? Estudiantes {  get; set; }
    }
}