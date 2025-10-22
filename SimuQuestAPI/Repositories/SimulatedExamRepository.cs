using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class SimulatedExamRepository : ISimulatedExamRepository
    {
        private readonly SimuQuestDbContext _context;
        public SimulatedExamRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(SimulatedExam exam)
        {
            await _context.SimulatedExams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SimulatedExam>> GetAll()
        {
            return await _context.SimulatedExams.Include(s => s.Questions).ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestoesAleatorias(int exameId, int quantidade)
        {
            return await _context.Questions
                .Where(q => q.SimulatedExamId == exameId)   // Filtra pelo exame
                .OrderBy(q => Guid.NewGuid())               // Embaralha aleatoriamente
                .Take(quantidade)                           // Pega só a quantidade desejada
                .Include(q => q.Options)                    // Inclui as opções
                .ToListAsync();                             // Materializa a lista
        }

        public async Task<SimulatedExam> GetById(int id)
        {
            return await _context.SimulatedExams.Include(s => s.Questions).ThenInclude(q => q.Options).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(SimulatedExam exam)
        {
            _context.SimulatedExams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exam = await _context.SimulatedExams.FirstOrDefaultAsync(e => e.Id == id);

            if (exam != null)
            {
                _context.SimulatedExams.Remove(exam);
                await _context.SaveChangesAsync();
            }

        }
    }
}
