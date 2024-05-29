using Risepay.Domain.Entities;
using Risepay.Infra.Interfaces;
using Risepay.Infra.Requests;

namespace Risepay.API.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<Colaborador>> GetAll()
        {
            return await _repository.GetAll();
        }       

        public async Task<string> Edit(ColaboradorRequest request, int id)
        {
            var colaborador = new Colaborador
            {
                Nome = request.nome,
                Email = request.email,
                Telefone = request.telefone,
                IdCargo = request.idcargo
            };

            string mensagemRequest = "Colaborador foi atualizado com sucesso!";

            await _repository.Edit(colaborador, id);

            return mensagemRequest;
        }

        public async Task<Colaborador> Create(Colaborador colaborador)
        {
            return await _repository.Create(colaborador);
        }

        public async Task<Colaborador> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
