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

    public class StatusController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public StatusController(IUsuarioBusiness usuarioBisiness)
        {
            _usuarioBusiness = usuarioBisiness;
        }

        
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_usuarioBusiness.ListarTodosUsuarios().First().Status);
        }
       
        
    }
}
