using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class SimulatedResultRepository : ISimulatedResultRepository
    {
        private readonly SimuQuestDbContext _context;

        public SimulatedResultRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(SimulatedResult simulatedResult)
        {
            await _context.SimulatedResults.AddAsync(simulatedResult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SimulatedResult>> GetAll()
        {
            return await _context.SimulatedResults.Include(s => s.SimulatedExam).ToListAsync();
        }

        public async Task<SimulatedResult> GetById(int id)
        {
            return await _context.SimulatedResults.Include(s => s.SimulatedExam).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(SimulatedResult simulatedResult)
        {
            _context.SimulatedResults.Update(simulatedResult);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var simulatedResult = await _context.SimulatedResults.FirstOrDefaultAsync(e => e.Id == id);
            if (simulatedResult != null)
            {
                _context.SimulatedResults.Remove(simulatedResult);
                await _context.SaveChangesAsync();
            }
        }

    }
}
