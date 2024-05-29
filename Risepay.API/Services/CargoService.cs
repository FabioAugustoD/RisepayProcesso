using Risepay.Domain.Entities;
using Risepay.Infra.Interfaces;

namespace Risepay.API.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Cargo>> GetAll()
        {
            return await _repository.GetAll();

        }
    }
}
