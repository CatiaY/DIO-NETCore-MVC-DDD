using CursoMVC_DDD.Domain.ValueTypes;
using Flunt.Notifications;

namespace CursoMVC_DDD.Domain.Entities
{
    public class Categoria : Notifiable
    {        
        public int Id { get; set; }
                
        public Descricao Descricao { get; }

        public Categoria(Descricao descricao)
        {
            AddNotifications(descricao.contract);

            if (Valid)
            {                
                Descricao = descricao;
            }
        }
    }
}