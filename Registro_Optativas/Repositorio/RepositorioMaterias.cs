using Microsoft.EntityFrameworkCore;
using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public class RepositorioMaterias : IRepositorioMaterias
    {
        private readonly RegistroDBContext _contexto;

        public RepositorioMaterias(RegistroDBContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Materia> Add(Materia materia)
        {
            await _contexto.Materias.AddAsync(materia);
            await _contexto.SaveChangesAsync();
            return materia;
        }
        public async Task Delete(int id)
        {
            var materia = await _contexto.Materias.FindAsync(id);
            if (materia != null)
            {
                _contexto.Materias.Remove(materia);
                await _contexto.SaveChangesAsync();
            }
        }
        public async Task<Materia?> Get(int id)
        {
            return await _contexto.Materias.FindAsync(id);
        }
        public async Task<List<Materia>> GetAll()
        {
            return await _contexto.Materias.ToListAsync();
        }
        public async Task Update(int id, Materia materia)
        {
            var materiaActual = await _contexto.Materias.FindAsync(id);
            if (materiaActual != null)
            {
                materiaActual.Id = materia.Id;
                materiaActual.Nombre = materia.Nombre;
                materiaActual.MaxLugares = materia.MaxLugares;
                materiaActual.Aula = materia.Aula;
                materiaActual.Descripcion = materia.Descripcion;
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
