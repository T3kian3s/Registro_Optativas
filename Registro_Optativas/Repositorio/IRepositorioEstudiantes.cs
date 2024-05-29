﻿using Registro_Optativas.Modelos;

namespace Registro_Optativas.Repositorio
{
    public interface IRepositorioEstudiantes
    {
        Task<List<Estudiante>> GetAll();
        Task<Estudiante?> Get(int id);
        Task<List<Materia>> GetMateria();
        Task<Estudiante> Add(Estudiante estudiante);
        Task Update(int id, Estudiante estudiante);
        Task Delete(int id);
        Task<bool> Existente(string numeroDeCuenta);
        Task<bool> CupoLimite(int materiaId);
        Task<List<Estudiante>> GetRegistrados(int materiaId);
    }
}