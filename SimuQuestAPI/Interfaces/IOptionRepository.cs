using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface IOptionRepository
    {
        Task Add(Option option);
        Task<IEnumerable<Option>> GetAll();
        Task<Option> GetById(int id);
        Task Update(Option option);
        Task Delete(int id);
    }
}
