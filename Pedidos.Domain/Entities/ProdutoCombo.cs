
namespace Pedidos.Domain
{
    public class ProdutoCombo
    {
        public int produtoid { get; set; }
        public virtual Produto Produto { get; set; }
        public int comboid { get; set; }
        public virtual Combo Combos { get; set; }
    }
}
