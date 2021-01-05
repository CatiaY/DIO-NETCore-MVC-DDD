using CursoMVC_DDD.Domain.Entities;
using System.Collections.Generic;

namespace CursoMVC_DDD.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDescricao(string descricao);
        
        IEnumerable<Produto> BuscarPorCategoria(int idCategoria);
    }
}
