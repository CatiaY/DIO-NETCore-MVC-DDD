using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CursoMVC_DDD.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _repository.GetById(id);
            _repository.Delete(obj);
        }
    }
}
