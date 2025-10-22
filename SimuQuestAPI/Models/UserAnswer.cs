using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }


        public int SimulatedResultId { get; set; }
        public SimulatedResult SimulatedResult { get; set; }

        public ICollection<SelectedOption> SelectedOptions { get; set; } = new List<SelectedOption>();
        public bool IsCorrect { get; set; } 
    }
}
