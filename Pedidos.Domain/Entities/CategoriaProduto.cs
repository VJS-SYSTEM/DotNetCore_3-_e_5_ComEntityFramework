using Pedidos.Domain.Interfaces;
using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class CategoriaProduto : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public bool ativo { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
