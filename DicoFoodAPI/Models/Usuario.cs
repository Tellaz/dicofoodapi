using DicoFoodAPI.Models.Base;

namespace DicoFoodAPI.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string NumeroWhats { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
