using Microsoft.EntityFrameworkCore;
using Risepay.Domain.Entities;
using Risepay.Infra.Context;
using Risepay.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risepay.Infra.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly AppDbContext _context;

        public CargoRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cargo>> GetAll()
        {
            return await _context.Cargos.ToListAsync();
        }
    }
}
