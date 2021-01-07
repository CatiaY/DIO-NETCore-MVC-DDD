using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.Interfaces;
using CursoMVC_DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CursoMVC_DDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MySqlContext context) : base(context)
        {
        }

        public override IEnumerable<Produto> GetAll()
        {
            return Db.Set<Produto>().Include("Categoria").ToList();
        }

        public override Produto GetById(int id)
        {            
            return Db.Set<Produto>().Include("Categoria").FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produto> BuscarPorDescricao(string descricao)
        {
            return Db.Tbl_Produtos.Where(p => p.Descricao.ToString().Contains(descricao));
        }

        public IEnumerable<Produto> BuscarPorCategoria(int idCategoria)
        {
            return Db.Tbl_Produtos.Where(p => p.CategoriaId == idCategoria);
        }
    }
}
