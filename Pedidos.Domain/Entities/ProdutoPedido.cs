namespace Pedidos.Domain
{
    public class ProdutoPedido : BaseDomain
    {
        public int quantidade { get; set; }
        public decimal preco { get; set; }
        public int produtoid { get; set; }
        public virtual Produto Produto { get; set; }
        public int pedidoid { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
