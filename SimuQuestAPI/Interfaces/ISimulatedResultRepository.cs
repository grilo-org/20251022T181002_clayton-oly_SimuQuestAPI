using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface ISimulatedResultRepository
    {
        Task Add(SimulatedResult simulatedResult);
        Task<IEnumerable<SimulatedResult>> GetAll();
        Task<SimulatedResult> GetById(int id);
        Task Update(SimulatedResult simulatedResult);
        Task Delete(int id);
    }
}
