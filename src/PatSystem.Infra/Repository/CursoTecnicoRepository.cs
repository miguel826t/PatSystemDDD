using Microsoft.EntityFrameworkCore;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using PatSystem.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatSystem.Infra.Repository
{
    public class CursoTecnicoRepository
    {
        private readonly PatSystemContext _context;

        public CursoTecnicoRepository(PatSystemContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(CursoTecnico obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAllAsync(List<CursoTecnico> objs)
        {
            foreach (var obj in objs)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }

        }

        public async Task RemoveAllAsync(int curriculoId)
        {
            var Cursos = await _context.CursoTecnico.Where(c => c.CurriculoID == curriculoId).ToListAsync();
            foreach (var curso in Cursos)
            {
                _context.CursoTecnico.Remove(curso);
                await _context.SaveChangesAsync();
            }

        }


        public async Task<CursoTecnico> FindByIdAsync(int id)
        {
            return await _context.CursoTecnico.FirstOrDefaultAsync(obj => obj.CurriculoID == id);
        }

        public async Task<List<CursoTecnico>> FindAllByIdAsync(int id)
        {
            return await _context.CursoTecnico.Where(obj => obj.CurriculoID == id).ToListAsync();
        }
    }
}
