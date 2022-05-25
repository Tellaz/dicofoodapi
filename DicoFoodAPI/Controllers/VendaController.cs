using DicoFoodAPI.Business.Interfaces;
using DicoFoodAPI.Models.Context;
using DicoFoodAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DicoFoodAPI.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    //[Authorize]
    public class VendaController : Controller
    {
        private readonly IVendaBusiness _repository;
        private readonly AppDbContext _context;

        public VendaController(IVendaBusiness repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "employee, admin")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.ListarVendasPorId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [ProducesResponseType((200), Type = typeof(List<VendaViewModel>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "employee, admin")]
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_repository.ListarVendas());
        }
        [HttpGet("relatorio")]
        public IActionResult Relatory()
        {
            var r = _context.Lanches.FromSqlRaw(@"select *
                                    from Lanches ").ToList(); 
            var v = _context.Venda.FromSqlRaw(@"select *
                                    from Venda ").ToList();
            var vi = _context.VendaItens.FromSqlRaw(@"select *
                                    from VendaItens ").ToList();



            return Ok(new {r, v, vi});
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles ="admin")]
        [HttpPut]
        public IActionResult Put([FromBody] VendaViewModel vendaVM)
        {
            if (vendaVM == null || !ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_repository.AtualizarVenda(vendaVM));
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost]
        public IActionResult Post ([FromBody] VendaViewModel vendaVM)
        {
            if (vendaVM == null || !ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_repository.CriarVenda(vendaVM));
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _repository.DeletarVenda(id);
            return NoContent();
        }
    }
}
