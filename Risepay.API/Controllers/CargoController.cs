using Microsoft.AspNetCore.Mvc;
using Risepay.Domain.Entities;
using Risepay.Infra.Interfaces;
using Risepay.Infra.Requests;

namespace Risepay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            var result = await _service.GetAll();

            return Ok(result);
        }
        
    }
}
