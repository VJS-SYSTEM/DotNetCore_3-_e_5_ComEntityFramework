using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain;
using Pedidos.Interface;
using System;
using System.Collections.Generic;

namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {

        public ProdutoController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        [HttpGet]
        public dynamic Get([FromQuery] string ordem = "")
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Get(ordem);
        }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public dynamic GetSearch(string text, int pagina = 1, string ordem = "")
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Search(text, pagina, ordem);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic Detail(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
                return rep.Detail(id.Value);
            }
            else
                return null;
            
        }

        [HttpGet]
        [Route("{id}/imagens")]
        public dynamic Imagens(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
                return rep.Imagens(id.Value);
            }
            else
                return null;

        }

    }

}
