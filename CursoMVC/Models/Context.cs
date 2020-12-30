using Microsoft.EntityFrameworkCore;

namespace CursoMVC.Models
{
    // Classe para a construção do Banco de dados
    public class Context : DbContext
    {
        // Cria uma tabela chamada Categorias do tipo Categoria ao ser executado
        public virtual DbSet<Categoria> Categorias { get; set; }

        // Cria uma tabela chamada Produtos ao ser executado
        public virtual DbSet<Produto> Produtos { get; set; }

        // Sobrescreve o método da classe herdada
        // Esse método é responsável por configurar a Entity Framework, informando qual banco de dados será utilizado
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            // Recebe como parâmetro uma string de conexão
            // O banco de dados se chamará Cursomvc e a string de conexão é o localdb\mssqllocaldb
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
        }


        // Método chamado nos Controllers do projeto API no método PUT
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}