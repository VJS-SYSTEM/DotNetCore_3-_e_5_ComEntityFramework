using Pedidos.Domain.Interfaces;
using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Cliente : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public int enderecoid { get; set; }
        public virtual Endereco Endereco { get; set; }
        public bool ativo { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
