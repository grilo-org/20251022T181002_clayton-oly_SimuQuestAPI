using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimuQuestDbContext _context;

        public UserRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByLoginAsync(string email, string senha)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}
