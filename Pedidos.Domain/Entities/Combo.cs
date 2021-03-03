using Pedidos.Domain.Interfaces;
using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Combo : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public decimal preco { get; set; }

        public int imagemid { get; set; }
        public virtual Imagem Imagem { get; set; }
        public virtual List<Produto> Produto { get; set; }
        public bool ativo { get; set; }
    }
}
