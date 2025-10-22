using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuQuestAPI.Data;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SimuQuestDbContext _context;
        public QuestionRepository(SimuQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task CreateQuestionsBatch(int examId, List<Question> questions)
        {
            var exam = await _context.SimulatedExams.FindAsync(examId);

            if (exam != null)
            {
                {
                    foreach (var question in questions)
                    {
                        await _context.Questions.AddAsync(question);
                        await _context.SaveChangesAsync();
                    }
                }

            }
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _context.Questions.Include(q => q.Options).ToListAsync();
        }

        public async Task<Question> GetById(int id)
        {
            return await _context.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task Update(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var question = await _context.SimulatedExams.FirstOrDefaultAsync(e => e.Id == id);

            if (question != null)
            {
                _context.SimulatedExams.Remove(question);
                await _context.SaveChangesAsync();
            }

        }
    }
}
