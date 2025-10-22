using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface IUserAnswerRepository
    {
        Task Add(UserAnswer userAnswer);
        Task<IEnumerable<UserAnswer>> GetAll();
        Task<UserAnswer> GetById(int id);
        Task Update(UserAnswer userAnswer);
        Task Delete(int id);
    }
}
