using CursoMVC_DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoMVC_DDD.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Tbl_Produtos");

            builder.HasKey(prop => prop.Id);             
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();  // Incrementa automaticamente

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Descrição")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("dec");

            builder.Property(p => p.Disponivel)
                .IsRequired();                

            // Chave estrangeira para a Categoria
            builder.HasOne(p => p.Categoria)
                .WithMany().HasForeignKey(fk => fk.CategoriaId);
        }
    }
}
