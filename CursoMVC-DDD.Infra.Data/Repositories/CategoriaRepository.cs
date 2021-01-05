using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Infra.Data.Context;

namespace CursoMVC_DDD.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MySqlContext context) : base(context)
        {
        }
    }
}
