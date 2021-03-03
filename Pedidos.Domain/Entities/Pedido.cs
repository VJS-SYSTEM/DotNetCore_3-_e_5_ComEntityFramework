using System;
using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Pedido : BaseDomain
    {
        public string numero { get; set; }
        public decimal valortotal { get; set; }
        public TimeSpan entrega { get; set; }
        public int clienteid { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<ProdutoPedido> Produto { get; set; }
    }
}
