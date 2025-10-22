using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Data
{
    public class SimuQuestDbContext : DbContext
    {
        public SimuQuestDbContext(DbContextOptions<SimuQuestDbContext> options) : base(options) { }

        public DbSet<SimulatedExam> SimulatedExams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<SimulatedResult> SimulatedResults { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<SelectedOption> SelectedOptions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
