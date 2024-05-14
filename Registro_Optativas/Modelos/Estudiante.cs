using System.ComponentModel.DataAnnotations;

namespace Registro_Optativas.Modelos
{
    public class Estudiante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El 'Nombre' es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El 'Numero de cuenta' es requerido.")]
        [StringLength(8, ErrorMessage = "Máximo 8 caracteres.")]
        public string? NumeroDeCuenta { get; set; }
        [Required(ErrorMessage = "El 'Correo' es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string? Correo { get; set; }
        // Propiedad de navegacion EF
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una materia")]
        public int MateriaId {  get; set; }
        virtual public Materia? Materia { get; set; }
    }
}