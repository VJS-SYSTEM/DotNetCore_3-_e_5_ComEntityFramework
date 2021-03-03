using Microsoft.Extensions.DependencyInjection;
using Pedidos.Interface;
using Pedidos.Repository;

namespace Pedidos.Api
{
    public class DependencyInjection
    {
        public static  void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependency(serviceProvider);
        }

        public static void RepositoryDependency(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceProvider.AddScoped<IPedidoRepository, PedidoRepository>();
            serviceProvider.AddScoped<ICidadeRepository, CidadeRepository>();

        }
    }
}
