using Microsoft.EntityFrameworkCore;
using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.Infra.Repository
{
    public class ExperienciaRepository
    {
        private readonly PatSystemContext _context;

        public ExperienciaRepository(PatSystemContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Experiencia obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAllAsync(List<Experiencia> objs)
        {
            foreach (var obj in objs)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }

        }

        public async Task RemoveAllAsync(int curriculoId)
        {
            var Objs = await _context.Experiencia.Where(c => c.CurriculoID == curriculoId).ToListAsync();
            foreach (var obj in Objs)
            {
                _context.Experiencia.Remove(obj);
                await _context.SaveChangesAsync();
            }

        }


        public async Task<Experiencia> FindByIdAsync(int id)
        {
            return await _context.Experiencia.FirstOrDefaultAsync(obj => obj.CurriculoID == id);
        }

        public async Task<List<Experiencia>> FindAllByIdAsync(int id)
        {
            return await _context.Experiencia.Where(obj => obj.CurriculoID == id).ToListAsync();
        }
    }
}
