using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Infra.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace CursoMVC_DDD.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        // Cria uma tabela chamada Categorias do tipo Categoria ao ser executado
        public virtual DbSet<Categoria> Tbl_Categorias { get; set; }

        // Cria uma tabela chamada Produtos ao ser executado
        public virtual DbSet<Produto> Tbl_Produtos { get; set; }


        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CursoMVC-DDD;Integrated Security=True");
        //}


        // Esse método é responsável por configurar a Entity Framework, informando qual banco de dados será utilizado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Indicar as classes de mapemaneto do Bando de Dados
            modelBuilder.Entity<Categoria>(new CategoriaMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);

            //modelBuilder.ApplyConfiguration(new CategoriaMap());
            //modelBuilder.ApplyConfiguration(new ProdutoMap());

            var entites = Assembly
                .Load("CursoMVC-DDD.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "CursoMVC-DDD.Domain.Entities" && w.BaseType == typeof(Notifiable));

            foreach (var item in entites)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }

            modelBuilder.Ignore<Notification>();           
        }       
    }
}
