using DicoFoodAPI.Models.Base;

namespace DicoFoodAPI.Models
{
    public class VendaItens : BaseEntity
    {
        public string CodigoVenda { get; set; }
        public int IdLanche { get; set; }
        public int Quantidade { get; set; }
    }
}
