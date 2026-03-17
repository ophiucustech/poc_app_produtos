using ApiProdutos.Application.Services;
using ApiProdutos.Domain;
using ApiProdutos.Domain.Abstractions.Repositories;
using ApiProdutos.Domain.Abstractions.Services;
using ApiProdutos.Infra.Data;
using ApiProdutos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace ApiProdutos.CrossCutting.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddDistribuidoraDatabase(this IServiceCollection services)
        {
            return services.AddDbContext<DistribuidoraContext>(options =>
                                    options.UseInMemoryDatabase("DistribuidoraDb"));
        }

        public static IServiceCollection AddDistribuidoraCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
             {
                 options.AddPolicy(name: "appprodutos_angular",
                     policy =>
                     {
                         policy.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                     });
             });
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }

    }
}
