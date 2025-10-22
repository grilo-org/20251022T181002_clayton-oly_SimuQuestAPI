using SimuQuestAPI.Models;

namespace SimuQuestAPI.Interfaces
{
    public interface ISimulatedExamRepository
    {
        Task Add(SimulatedExam exam);
        Task<IEnumerable<SimulatedExam>> GetAll();
        Task<IEnumerable<Question>> GetQuestoesAleatorias(int exameId, int quantidade);
        Task<SimulatedExam> GetById(int id);
        Task Update(SimulatedExam exam);
        Task Delete(int id);
    }
}
