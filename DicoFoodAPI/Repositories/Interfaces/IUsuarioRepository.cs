using DicoFoodAPI.Models;

namespace DicoFoodAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}
