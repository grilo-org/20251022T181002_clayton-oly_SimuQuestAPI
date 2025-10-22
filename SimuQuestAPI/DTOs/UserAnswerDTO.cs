namespace SimuQuestAPI.DTOs
{
    public class UserAnswerDTO
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public bool IsCorrect { get; set; }
        public List<SelectedOptionDTO> SelectedOptions { get; set; } = new();
    }
}
