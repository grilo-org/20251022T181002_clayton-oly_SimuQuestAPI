namespace SimuQuestAPI.DTOs
{
    public class SelectedOptionDTO
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; } // mostra se a opção era a correta
        public bool WasChosen { get; set; } // mostra se o usuário escolheu
    }
}
