using System;


namespace Pedidos.Domain
{
    public abstract class BaseDomain
    {
        public int id { get; set; }
        public DateTime criadoem { get; set; }
    }
}
