using CursoMVC_DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoMVC_DDD.Infra.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Tbl_Categorias");

            builder.HasKey(prop => prop.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();  // Incrementa automaticamente

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Descrição")
                .HasColumnType("varchar(100)");
        }    
    }
}
