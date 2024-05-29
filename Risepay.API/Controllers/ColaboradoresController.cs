using Microsoft.AspNetCore.Mvc;
using Risepay.Domain.Entities;
using Risepay.Infra.Interfaces;
using Risepay.Infra.Requests;


namespace Risepay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorService _service;

        public ColaboradoresController(IColaboradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
            var result = await _service.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Colaborador>> CreateColaborador([FromBody] ColaboradorRequest request)
        {
            var colaborador = new Colaborador
            {
                Nome = request.nome,
                Email = request.email,
                Telefone = request.telefone,
                IdCargo = request.idcargo
            };

            await _service.Create(colaborador);
            return Ok(colaborador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ColaboradorRequest request, int id)
        {
            try
            {
                var response = await _service.Edit(request, id);
                return new JsonResult(new { mensagem = response });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Falha na requisição de update", erro = ex.Message });
            }
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> SearchByName(string nome)
        {
            try
            {
                var response = await _service.SearchByName(nome);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Falha na requisição de busca", erro = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var colaborador = await _service.GetById(id);
               
                if (colaborador != null)
                {                    
                    return Ok(colaborador);
                }
                else
                {                    
                    return NotFound($"Colaborador com o ID {id} não encontrado");
                }
            }
            catch (Exception ex)
            {               
                return BadRequest($"Erro ao buscar colaborador: {ex.Message}");
            }
        }
    }
}
