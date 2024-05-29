using Risepay.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Domain.Entities
{
    public class Colaborador : BaseModel
    {        
        public string Nome { get; set; }
        public string Email { get; set;}
        public string Telefone { get; set;}
        public int IdCargo { get; set;}
        public Cargo Cargo { get; set; }

    }
}
