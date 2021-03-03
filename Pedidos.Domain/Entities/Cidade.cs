using Pedidos.Domain.Interfaces;


namespace Pedidos.Domain
{
    public class Cidade : BaseDomain, IExibivel
    {
        public string nome { get; set; }
        public string uf { get; set; }
        public bool ativo { get; set; }
    }
}
