using Microsoft.EntityFrameworkCore;
using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public class RepositorioProfesores : IRepositorioProfesores
    {
        private readonly RegistroDBContext _contexto;

        public RepositorioProfesores(RegistroDBContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Profesor> Add(Profesor profesor)
        {
            await _contexto.Profesores.AddAsync(profesor);
            await _contexto.SaveChangesAsync();
            return profesor;
        }
        public async Task Delete(int id)
        {
            var profesor = await _contexto.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _contexto.Profesores.Remove(profesor);
                await _contexto.SaveChangesAsync();
            }
        }
        public async Task<Profesor?> Get(int id)
        {
            return await _contexto.Profesores.FindAsync(id);
        }

        public async Task<List<Profesor>> GetAll()
        {
            return await _contexto.Profesores.Include(r => r.Materia).ToListAsync();
        }
        public async Task<List<Materia>> GetMateria()
        {
            return await _contexto.Materias.ToListAsync();
        }
        public async Task Update(int id, Profesor profesor)
        {
            var profesorActual = await _contexto.Profesores.FindAsync(id);
            if (profesorActual != null)
            {
                profesorActual.Id = profesor.Id;
                profesorActual.Nombre = profesor.Nombre;
                profesorActual.Correo = profesor.Correo;
                profesorActual.Telefono = profesor.Telefono;
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
