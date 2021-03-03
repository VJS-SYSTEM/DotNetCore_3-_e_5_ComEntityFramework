using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Imagem : BaseDomain
    {
        public string nome { get; set; }
        public string nomearquivo { get; set; }
        public bool principal { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
