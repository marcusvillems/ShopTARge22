using Microsoft.Extensions.DependencyInjection;
using ShopTARge22.Data;
using ShopTARge22.ApplicationServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShopTARge22.RealEstateTest.Macros;
using ShopTARge22.Core.ServiceInterface;
using Microsoft.Extensions.Hosting;
using ShopTARge22.RealEstateTest.Mock;
using ShopTARge22.SpaceshipTest.SpaceshipMacros;

namespace ShopTARge22.RealEstateTest
{
    public abstract class SpaceshipTestBase
    {
        protected IServiceProvider serviceProvider { get; }

        protected SpaceshipTestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {

        }
        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : ISpaceshipMacros
        {
            return serviceProvider.GetService<T>();
        }
        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            services.AddDbContext<ShopTARge22Context>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            RegisterMacros(services);
        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !!x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
