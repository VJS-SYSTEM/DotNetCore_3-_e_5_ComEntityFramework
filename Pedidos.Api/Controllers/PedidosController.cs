using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : AppBaseController
    {

        public PedidosController(IServiceProvider serviceprovider):base(serviceprovider)
        {
        }
        [HttpGet]
        [Route("ticket-maximo")]
        public decimal TicketMaximo()
        {
            var rep = (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository));
            return rep.TicketMaximo();  

        }

        [HttpGet]
        [Route("por-cliente")]
        public dynamic PedidosClientes()
        {
            var rep = (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository));
            return rep.PedidosClientes();
        }

    }
}
