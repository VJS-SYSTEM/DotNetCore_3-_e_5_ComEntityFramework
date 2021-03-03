using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain
{
    public class CidadeDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public bool ativo { get; set; }
    }
}
