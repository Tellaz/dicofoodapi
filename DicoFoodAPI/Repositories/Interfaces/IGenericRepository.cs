using DicoFoodAPI.Models.Base;
using System.Collections.Generic;

namespace DicoFoodAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Criar(T item);
        T Atualizar(T item);
        List<T> ListarTodos();
        void Deletar(int id);
        T EncontrarPorId(int id);
    }
}
