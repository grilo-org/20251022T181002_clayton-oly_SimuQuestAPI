using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int Ordem { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
