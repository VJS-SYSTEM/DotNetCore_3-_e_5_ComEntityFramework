using Pedidos.Domain;
using System.Collections.Generic;

namespace Pedidos.Interface
{
    public interface IPedidoRepository
    {
        decimal TicketMaximo();
        dynamic PedidosClientes();
    }
}
