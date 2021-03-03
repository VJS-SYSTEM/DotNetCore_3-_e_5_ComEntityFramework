using Pedidos.Domain.Interfaces;
using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Produto : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int categoriaid { get; set; }
        public virtual CategoriaProduto Categoria { get; set; }
        public virtual List<Imagem> Imagens { get; set; }
        public virtual List<PromocaoProduto> PromocaoProdutos { get; set; }
        public virtual List<Combo> Combos { get; set; }

        public bool ativo { get; set; }
    }
}
