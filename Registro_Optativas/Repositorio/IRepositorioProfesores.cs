using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public interface IRepositorioProfesores
    {
        Task<List<Profesor>> GetAll();
        Task<Profesor?> Get(int id);
        Task<List<Materia>> GetMateria();
        Task<Profesor> Add(Profesor profesor);
        Task Update(int id, Profesor profesor);
        Task Delete(int id);
        Task<bool> TelefonoExistente(string telefono);
        Task<bool> MateriaExistente(int materiaId);
    }
}