using Marmitex.Data.Context;
using Marmitex.Data.Repositories;
using Marmitex.Domain.Interfaces;
using Marmitex.Domain.Services.ClasseParaJson;
using Marmitex.Domain.Services.Cookie;
using Marmitex.Domain.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Marmitex.DI
{
    public class Init
    {
        public static void ConfigureServices(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conection));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped(typeof(IAcompanhamentoRepository), typeof(AcompanhamentoRepository));
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddScoped(typeof(IItensPedidoRepository), typeof(ItensPedidoRepository));
            services.AddScoped(typeof(IMarmitaRepository), typeof(MarmitaRepository));
            services.AddScoped(typeof(IMisturaRepository), typeof(MisturaRepository));
            services.AddScoped(typeof(IPedidoRepository), typeof(PedidoRepository));
            services.AddScoped(typeof(ISaladaRepository), typeof(SaladaRepository));
            services.AddScoped(typeof(IJsonService), typeof(JsonService));
            services.AddScoped(typeof(ICookieService), typeof(CookieService));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ICardapioRepository<>), typeof(CardapioRepository<>));
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Transient);
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // services

        }
    }
}