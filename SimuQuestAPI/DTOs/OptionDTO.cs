namespace SimuQuestAPI.DTOs
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public bool Correta { get; set; }
        public int? Ordem { get; set; }

        public int QuestionId { get; set; }
        public string? Questao { get; set; }
    }
}
