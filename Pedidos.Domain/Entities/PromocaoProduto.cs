using Pedidos.Domain.Interfaces;

namespace Pedidos.Domain
{
    public class PromocaoProduto : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int imagemid { get; set; }
        public virtual Imagem Imagem { get; set; }
        public int produtoid { get; set; }
        public virtual Produto Produto { get; set; }

        public bool ativo { get; set; }
    }
}
