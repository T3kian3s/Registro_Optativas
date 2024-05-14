using Microsoft.EntityFrameworkCore;
using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public class RepositorioEstudiantes : IRepositorioEstudiantes
    {
        private readonly RegistroDBContext _contexto;

        public RepositorioEstudiantes(RegistroDBContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Estudiante> Add(Estudiante estudiante)
        {
                await _contexto.Estudiantes.AddAsync(estudiante);
                await _contexto.SaveChangesAsync();
                return estudiante;
        }
        public async Task Delete(int id)
        {
            var estudiante = await _contexto.Estudiantes.FindAsync(id);
            if (estudiante != null)
            { 
                _contexto.Estudiantes.Remove(estudiante);
                await _contexto.SaveChangesAsync();
            }
        }
        public async Task<Estudiante?> Get(int id)
        {
            return await _contexto.Estudiantes.FindAsync(id);
        }
        public async Task<List<Estudiante>> GetAll()
        {
            return await _contexto.Estudiantes.Include(r=>r.Materia).ToListAsync();
        }
        public async Task<List<Materia>> GetMateria()
        {
            return await _contexto.Materias.ToListAsync();
        }
        public async Task Update(int id, Estudiante estudiante)
        {
            var estudianteActual = await _contexto.Estudiantes.FindAsync(id);
            if (estudianteActual != null)
            {
                estudianteActual.Nombre = estudiante.Nombre;
                estudianteActual.NumeroDeCuenta = estudiante.NumeroDeCuenta;
                estudianteActual.Correo = estudiante.Correo;
                await _contexto.SaveChangesAsync();
            }
        }
    }
}