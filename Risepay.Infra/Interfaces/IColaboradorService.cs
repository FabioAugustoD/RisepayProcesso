using Risepay.Domain.Entities;
using Risepay.Infra.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Infra.Interfaces
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>>GetAll();
        Task<Colaborador> Create(Colaborador colaborador);
        Task<string> Edit(ColaboradorRequest request, int id);
        Task<Colaborador> GetById(int id);
    }
}
