using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Domain.Interfaces.Services;

namespace CursoMVC_DDD.Service.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
    }
}
