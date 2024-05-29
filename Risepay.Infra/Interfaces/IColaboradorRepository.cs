using Risepay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Infra.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<List<Colaborador>> GetAll();
        Task<Colaborador> GetById(int id);
        Task<Colaborador> Create(Colaborador colaborador);
        Task Edit(Colaborador colaborador, int id);
    }
}
