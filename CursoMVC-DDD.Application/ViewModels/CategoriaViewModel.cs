using CursoMVC_DDD.Domain.ValueTypes;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC_DDD.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos {1} caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }                        
    }
}
