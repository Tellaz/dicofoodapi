using DicoFoodAPI.Data.VO;
using System.Collections.Generic;

namespace DicoFoodAPI.Business.Interfaces
{
    public interface ILancheBusiness
    {
        LancheVO CriarLanche(LancheVO lanche);
        LancheVO AtualizarLanche(LancheVO lanche);
        List<LancheVO> ListarTodosLanches();
        void DeletarLanche(int id);
        LancheVO EncontrarPorId(int id);
        List<LancheVO> EncontrarPorNome(string Nome);
        List<LancheVO> LanchesPorCategoria(int categoria);
    }
}
