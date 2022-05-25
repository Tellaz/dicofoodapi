using DicoFoodAPI.Data.VO;
using DicoFoodAPI.Models;
using System.Collections.Generic;

namespace DicoFoodAPI.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        Usuario CriarUsuario(Usuario usuario);
        UsuarioVO AtualizarUsuario(UsuarioVO usuario);
        List<UsuarioVO> ListarTodosUsuarios();
        void DeletarUsuarios(int id);
        UsuarioVO EncontrarPorId(int id);
        Usuario Login(Usuario usuarioVO);
    }
}
