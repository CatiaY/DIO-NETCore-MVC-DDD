using CursoMVC_DDD.Domain.Interfaces.Services;
using CursoMVC_DDD.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CursoMVC_DDD.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
