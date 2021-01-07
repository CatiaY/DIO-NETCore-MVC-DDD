using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CursoMVC_DDD.Service.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;        

        public ProdutoService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;            
        }                    

        public IEnumerable<Produto> BuscarPorCategoria(int idCategoria)
        {
            return _produtoRepository.BuscarPorCategoria(idCategoria);
        }

        public IEnumerable<Produto> BuscarPorDescricao(string descricao)
        {
            return _produtoRepository.BuscarPorDescricao(descricao);
        }
    }
}
