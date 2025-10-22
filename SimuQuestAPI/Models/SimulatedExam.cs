using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class SimulatedExam
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Imagem { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
