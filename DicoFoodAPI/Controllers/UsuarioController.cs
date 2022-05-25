using DicoFoodAPI.Business.Interfaces;
using DicoFoodAPI.Data.VO;
using DicoFoodAPI.Models;
using DicoFoodAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static DicoFoodAPI.Models.ViewModels.UsuarioViewModel;

namespace DicoFoodAPI.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBisiness)
        {
            _usuarioBusiness = usuarioBisiness;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Get() //Lista todos os usuarios cadastrados
        {
            return Ok(_usuarioBusiness.ListarTodosUsuarios());
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("CriarConta")]
        public async Task<ActionResult<dynamic>> Post([FromBody] RegisterUsuarioViewModel registerVM)  //Após ter feito vi que poderia ter usado o mesmo VO para validar o model, e ter passado boa parte do codigo para o Business ou para o Repository onde faz mais sentido.
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));  // Mas é sempre assim, quando você termina vê que poderia ter feito de forma melhor.
            var usuario = new Usuario()
            {
                Nome = registerVM.Nome,
                Status = registerVM.Status,
                Email = registerVM.Email,
                Senha = registerVM.Senha,
                Role = registerVM.Role,
                NumeroWhats = registerVM.NumeroWhats

            };
            usuario = _usuarioBusiness.CriarUsuario(usuario);
            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }

        [Authorize(Roles ="admin")]
        [HttpPut]
        public IActionResult Put([FromBody] UsuarioVO usuario) //Atualiza Cadastro Usuario
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.AtualizarUsuario(usuario));
        }
        
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //Deleta Usuarios
        {
            _usuarioBusiness.DeletarUsuarios(id);
            return NoContent();
        }

        [Authorize(Roles ="admin")]
        [HttpGet("{id}")]
        public IActionResult Get(int id) //Encontra Usuario por ID
        {
            var usuario = _usuarioBusiness.EncontrarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginUsuarioViewModel LoginVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            var usuario = new Usuario()
            {
                Email = LoginVM.Email,
                Senha = LoginVM.Senha
            };
            usuario = _usuarioBusiness.Login(usuario);
            if (usuario == null) return BadRequest(new { message = "Usuario ou senha inválidos" });
            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
