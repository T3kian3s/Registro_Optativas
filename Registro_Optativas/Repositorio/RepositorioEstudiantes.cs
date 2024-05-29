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
                estudianteActual.Id = estudiante.Id;
                estudianteActual.Nombre = estudiante.Nombre;
                estudianteActual.NumeroDeCuenta = estudiante.NumeroDeCuenta;
                estudianteActual.Correo = estudiante.Correo;
                await _contexto.SaveChangesAsync();
            }
        }
        public async Task<bool> Existente(string numeroDeCuenta)
        {
            return await _contexto.Estudiantes.AnyAsync(e=>e.NumeroDeCuenta == numeroDeCuenta);
        }

        public async Task<bool> CupoLimite(int materiaId)
        {
            var materia = await _contexto.Materias.FindAsync(materiaId);
            if (materia == null) return false;

            int maxLugares;
            if(!int.TryParse(materia.MaxLugares, out maxLugares))
            {
                return false;
            }

            int inscritos = await _contexto.Estudiantes.CountAsync(e => e.MateriaId == materiaId);
            return inscritos >= maxLugares;
        }
        public async Task<List<Estudiante>> GetRegistrados(int materiaId)
        {
            return await _contexto.Estudiantes.Where(e => e.MateriaId == materiaId).ToListAsync();
        }
    }
}