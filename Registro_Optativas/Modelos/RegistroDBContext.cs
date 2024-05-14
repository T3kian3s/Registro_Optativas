using Microsoft.EntityFrameworkCore;

namespace Registro_Optativas.Modelos
{
    public class RegistroDBContext : DbContext
    {
        public RegistroDBContext(DbContextOptions<RegistroDBContext> options) : base(options)
        {
        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}