
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.KindergartenTest.KindergartenMarcos;
using ShopTARge22.KindergartenTest.KindergartenMock;
using System.Security.Authentication.ExtendedProtection;


namespace ShopTARge22.RealEstateTest
{
    public abstract class KindergartenTestBase
    {
        protected IServiceProvider serviceProvider { get; }
        protected KindergartenTestBase()
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
        protected T KindergartenMacros<T>() where T : KindergartenIMacros
        {
            return serviceProvider.GetService<T>();
        }
        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IKindergartenServices, KindergartenServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, KindergartenMockIHostEnvironment>();

            services.AddDbContext<ShopTARge22Context>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            RegisterMacros(services);
        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(KindergartenIMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !!x.IsInterface && !x.IsAbstract);

            foreach(var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}

