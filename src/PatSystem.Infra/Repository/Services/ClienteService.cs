using Microsoft.EntityFrameworkCore;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Infra.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatSystem.Infra.Repository.Services
{
    public class ClienteService
    {
        private readonly PatSystemContext _context;

        public ClienteService(PatSystemContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Cliente obj)
        {
            obj.Idade = DateTime.Now.Year - obj.Nascimento.Year;
            _context.Add(obj);
          await  _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int? id)
        {
            var obj = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task UpdateAsync(Cliente obj)
        {
            obj.Idade = DateTime.Now.Year - obj.Nascimento.Year;
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
