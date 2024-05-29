using System.ComponentModel.DataAnnotations;

namespace Registro_Optativas.Modelos
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El 'Nombre' es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Nombre {  get; set; }
        [Required(ErrorMessage = "El 'Correo' es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Correo {  get; set; }
        [Required(ErrorMessage = "El 'Teléfono' es requerido.")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres.")]
        public string? Telefono {  get; set; }

        // Propiedad de Navegacion EF.
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una materia")]
        public int MateriaId {  get; set; }
        virtual public Materia? Materia { get; set; }
    }
}