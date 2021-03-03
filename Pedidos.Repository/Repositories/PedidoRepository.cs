using Pedidos.Domain;
using Pedidos.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pedidos.Repository
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public decimal TicketMaximo()
        {
            var hoje = DateTime.Today;

            return _dbContext.Pedidos
                .Where(x => x.criadoem.Date == hoje)
                .Max(x => (decimal?)x.valortotal)?? 0;
        }

        public dynamic PedidosClientes()
        {
            var hoje = new DateTime(2021, 1, 1);   //DateTime.Today
            var inicioMes = new DateTime(hoje.Year, hoje.Month, 1);
            var fimMes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));
            return _dbContext.Pedidos
                .Where(x => x.criadoem.Date >= inicioMes && x.criadoem.Date <= fimMes)
                .GroupBy(
                pedido => new { pedido.clienteid, pedido.Cliente.nome }
                ,(chave, pedidos) => new
                {
                    Cliente = chave.nome,
                    Pedidos = pedidos.Count(),
                    Total = pedidos.Sum(pedido => pedido.valortotal)
                })
                .ToList();
                //.GroupBy(
                //pedido => new { pedido.clienteid, pedido.Cliente.nome })
                //.Select( x => new
                //{
                //    Cliente = x.Key.nome,
                //    Pedidos = x.Count(),
                //    Total = x.Sum(p => p.valortotal)
                //})
                //.ToList();
        }

    }
}
