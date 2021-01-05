using CursoMVC_DDD.Domain.ValueTypes;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoMVC_DDD.Domain.Entities
{
    public class Produto : Notifiable
    {
        public int Id { get; set; }
                
        public Descricao Descricao { get; }
                
        public int Quantidade { get; }
        
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Produto(Descricao descricao, int quantidade, int categoriaId)
        {
            AddNotifications(new Contract()
                .IsBetween(quantidade, 1, 10, "Quantidade", "A quantidade deve ser de 1 a 50")                
            );

            if (Valid)
            {                
                Descricao = descricao;
                Quantidade = quantidade;
                CategoriaId = categoriaId;
            }
        }
    }
}