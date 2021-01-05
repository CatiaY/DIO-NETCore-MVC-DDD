using CursoMVC_DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoMVC_DDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDescricao(string descricao);

        IEnumerable<Produto> BuscarPorCategoria(int idCategoria);
    }
}
