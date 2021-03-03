using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain;
using Pedidos.Interface;
using System;


namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {

        public CidadeController(IServiceProvider serviceprovider):base(serviceprovider)
        {
        }

        [HttpGet]
        public dynamic Get()
        {
            //var rep = (ICidadeRepository)_serviceProvider.GetService(typeof(ICidadeRepository));
            return GetService<ICidadeRepository>().Get();  

        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);

        }

        [HttpPut]
        public int Alterar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Alterar(model);

        }

        [HttpDelete]
        [Route("{id}")]
        public bool Excluir(int id)
        {
            return GetService<ICidadeRepository>().Excluir(id);

        }

    }
}
