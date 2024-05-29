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
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDbContext _context;
        public ColaboradorRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<Colaborador> Create(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
            return colaborador;
        }

        public async Task Edit(Colaborador colaborador, int id)
        {
            var existingColaborador = await _context.Colaboradores.FindAsync(id);

            if (existingColaborador != null)
            {
                existingColaborador.Nome = colaborador.Nome;
                existingColaborador.Email = colaborador.Email;
                existingColaborador.Telefone = colaborador.Telefone;
                existingColaborador.IdCargo = colaborador.IdCargo;

                _context.Colaboradores.Update(existingColaborador);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Colaborador não encontrado");
            }
        }


        public async Task<List<Colaborador>> GetAll()
        {
            var query = from c in _context.Colaboradores.Include(c => c.Cargo)
                        select c;

            return await query.ToListAsync();
        }

       public async Task<Colaborador> GetById(int id)
        {
            var colaborador = await _context.Colaboradores
                                  .Include(c => c.Cargo) 
                                  .FirstOrDefaultAsync(c => c.Id == id);

            if (colaborador != null)
            {
                return colaborador; 
            }
            else
            {
                return null; 
            }
        }

        public async Task<IEnumerable<Colaborador>> SearchByName(string nome)
        {
            return await _context.Colaboradores
                .Include(c => c.Cargo)
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

    }
}
