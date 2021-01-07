using CursoMVC_DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoMVC_DDD.Infra.CrossCutting.InversionOfControl
{
    public static class MySqlDependency
    {
        public static void AddMySqlDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MySqlContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CursoMVC-DDD;Integrated Security=True");                
            });
        }
     }
}
