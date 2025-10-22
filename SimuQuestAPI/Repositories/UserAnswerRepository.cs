using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly SimuQuestDbContext _context;
        public UserAnswerRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(UserAnswer userAnswer)
        {
            await _context.UserAnswers.AddAsync(userAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAnswer>> GetAll()
        {
            return await _context.UserAnswers.ToListAsync();
        }

        public async Task<UserAnswer> GetById(int id)
        {
            return await _context.UserAnswers.FindAsync(id);
        }

        public async Task Update(UserAnswer userAnswer)
        {
            await _context.UserAnswers.AddAsync(userAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userAnswer = await _context.UserAnswers.FirstOrDefaultAsync(u => u.Id == id);
            if (userAnswer != null)
            {
                _context.UserAnswers.Remove(userAnswer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
