using DicoFoodAPI.Models;
using System.Collections.Generic;

namespace DicoFoodAPI.Repositories.Interfaces
{
    public interface ILancheRepository : IGenericRepository<Lanche>
    {
        List<Lanche> EncontrarPorNome(string nome);
        List<Lanche> LanchesPorCategoria(int categoria);
    }
}
