using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CursoMVC_DDD.Infra.CrossCutting.InversionOfControl
{
    public static class MySqlRepositoryDependence
    {
        public static void AddMySqlRepositoryDependence(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
