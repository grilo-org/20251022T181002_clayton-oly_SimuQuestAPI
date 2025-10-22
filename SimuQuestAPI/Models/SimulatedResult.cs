using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class SimulatedResult
    {
        [Key]
        public int Id { get; set; }
        public int SimulatedExamId { get; set; }
        public SimulatedExam SimulatedExam { get; set; }

        //public string UsuarioId { get; set; }
        public DateTime DataConclusao { get; set; } = DateTime.UtcNow;
        public decimal Pontuacao { get; set; }
        public ICollection<UserAnswer> AnsweredQuestions { get; set; } = new List<UserAnswer>();
    }
}
