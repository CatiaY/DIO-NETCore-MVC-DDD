using System.Collections.Generic;

namespace CursoMVC_DDD.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Upddate(TEntity obj);

        void Delete(TEntity obj);
    }
}
