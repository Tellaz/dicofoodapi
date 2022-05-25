using DicoFoodAPI.Models;
using DicoFoodAPI.Models.Context;
using DicoFoodAPI.Repositories.Interfaces;
using System.Linq;

namespace DicoFoodAPI.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }

        public Usuario Login(Usuario usuario)
        {
            var result = _context.Usuarios.SingleOrDefault(x => x.Email.Equals(usuario.Email) && x.Senha.Equals(usuario.Senha));
            if (result == null) return null;
            return result;
        }
    }
}
