using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class SelectedOption
    {
        [Key]
        public int Id { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }

        public int AnsweredQuestionId { get; set; }
        public UserAnswer AnsweredQuestion { get; set; }
    }
}
