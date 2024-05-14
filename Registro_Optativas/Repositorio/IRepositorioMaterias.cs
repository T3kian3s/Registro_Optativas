using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public interface IRepositorioMaterias
    {
        Task<List<Materia>> GetAll();
        Task<Materia?> Get(int id);
        Task<Materia> Add(Materia materia);
        Task Update(int id, Materia materia);
        Task Delete(int id);
    }
}
