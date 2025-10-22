namespace SimuQuestAPI.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public string? Explicacao { get; set; }
        public int Ordem { get; set; }

        public int ExamId { get; set; }
        public string? NomeExame { get; set; }

        public ICollection<OptionDTO> Options { get; set; } = new List<OptionDTO>();
    }
}
