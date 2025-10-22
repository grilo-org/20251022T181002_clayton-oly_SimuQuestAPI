namespace SimuQuestAPI.DTOs
{
    public class SimulatedExamDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Imagem { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
    }
}
