namespace SimuQuestAPI.DTOs
{
    public class SimulatedResultDTO
    {
        public int Id { get; set; }
        public int SimulatedExamId { get; set; }
        public string SimulatedExamTitle { get; set; } // opcional
        public DateTime DataConclusao { get; set; }
        public decimal Pontuacao { get; set; }
        public List<UserAnswerDTO> Answers { get; set; } = new();
    }
}
