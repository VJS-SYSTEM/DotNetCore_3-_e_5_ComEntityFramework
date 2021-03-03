using System;
using Microsoft.Extensions.DependencyInjection;


namespace Pedidos.Api
{

    public class AppBaseController
    {
        public readonly IServiceProvider _serviceProvider;
        protected T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
        public  AppBaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        
    }
}
