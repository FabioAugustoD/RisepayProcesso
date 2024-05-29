using Risepay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Infra.Requests
{
    public record ColaboradorRequest(string nome, string email, string telefone, int idcargo);    
}
