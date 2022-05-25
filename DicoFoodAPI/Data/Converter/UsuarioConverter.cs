using DicoFoodAPI.Data.Converter.Interface;
using DicoFoodAPI.Data.VO;
using DicoFoodAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DicoFoodAPI.Data.Converter
{
    public class UsuarioConverter : IParser<Usuario, UsuarioVO>, IParser<UsuarioVO, Usuario>
    {
        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email,
                Status = origin.Status,
                NumeroWhats = origin.NumeroWhats,
                Senha = origin.Senha,
                Role = origin.Role
            };
        }

        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email,
                Status = origin.Status,
                NumeroWhats = origin.NumeroWhats,
                Senha = origin.Senha,
                Role = origin.Role
            };
        }

        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
