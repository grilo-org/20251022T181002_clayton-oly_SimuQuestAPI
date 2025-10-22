using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface ISelectedOptionRepository
    {
        Task Add(SelectedOption selectedOption);
        Task<IEnumerable<SelectedOption>> GetAll();
        Task<SelectedOption> GetById(int id);
        Task Update(SelectedOption selectedOption);
        Task Delete(int id);
    }
}
