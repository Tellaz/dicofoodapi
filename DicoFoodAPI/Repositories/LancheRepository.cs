using DicoFoodAPI.Models;
using DicoFoodAPI.Models.Context;
using DicoFoodAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DicoFoodAPI.Repositories
{
    public class LancheRepository : GenericRepository<Lanche>, ILancheRepository
    {
        public LancheRepository(AppDbContext context) : base(context) {}

        public List<Lanche> EncontrarPorNome(string nome)
        {
            return _context.Lanches.Where(l => l.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public List<Lanche> LanchesPorCategoria(int categoria)
        {
            return _context.Lanches.ToList();
        }
    }
}
