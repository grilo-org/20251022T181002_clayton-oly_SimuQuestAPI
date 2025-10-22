using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class SelectedOptionRepository : ISelectedOptionRepository
    {
        private readonly SimuQuestDbContext _context;
        public SelectedOptionRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(SelectedOption selectedOption)
        {
            await _context.SelectedOptions.AddAsync(selectedOption);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectedOption>> GetAll()
        {
            return await _context.SelectedOptions.ToListAsync();
        }

        public async Task<SelectedOption> GetById(int id)
        {
            return await _context.SelectedOptions.FindAsync(id);
        }

        public async Task Update(SelectedOption selectedOption)
        {
            _context.SelectedOptions.Update(selectedOption);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var selectedOption = await _context.SelectedOptions.FirstOrDefaultAsync(s => s.Id == id);

            if (selectedOption != null)
            {
                _context.SelectedOptions.Update(selectedOption);
                await _context.SaveChangesAsync();
            }
        }
    }
}
