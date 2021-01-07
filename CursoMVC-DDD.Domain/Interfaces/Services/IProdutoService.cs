using CursoMVC_DDD.Domain.Entities;
using System.Collections.Generic;

namespace CursoMVC_DDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDescricao(string descricao);

        IEnumerable<Produto> BuscarPorCategoria(int idCategoria);        
    }
}
