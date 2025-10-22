using System.ComponentModel.DataAnnotations;

namespace SimuQuestAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
