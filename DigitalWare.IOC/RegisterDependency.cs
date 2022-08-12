using DigitalWare.CORE.CleintesCore;
using DigitalWare.CORE.ClientesCore.Interfaces;
using DigitalWare.CORE.ProductosCore;
using DigitalWare.CORE.ProductosCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalWare.IOC
{
    public class RegisterDependency
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IProductosCore, ProductosCore>();
            services.AddScoped<IClientesCore, ClientesCore>();
            #endregion

        }
    }
}
