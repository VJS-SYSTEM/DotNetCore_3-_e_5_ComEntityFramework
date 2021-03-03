using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain
{
    public class ImagemProduto
    {
        public int imagemid { get; set; }
        public virtual Imagem Imagens { get; set; }
        public int produtoid { get; set; }

        public virtual Produto Produtos { get; set; }
    }
}
