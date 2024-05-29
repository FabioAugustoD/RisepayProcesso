using Risepay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Infra.Interfaces
{
    public interface ICargoService
    {
        Task<List<Cargo>> GetAll();
    }
}
