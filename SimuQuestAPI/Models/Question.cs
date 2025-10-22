using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Statement { get; set; } = string.Empty;
        public string? Explicacao { get; set; }
        public int Ordem { get; set; }

        public int SimulatedExamId { get; set; }
        public SimulatedExam SimulatedExam { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
