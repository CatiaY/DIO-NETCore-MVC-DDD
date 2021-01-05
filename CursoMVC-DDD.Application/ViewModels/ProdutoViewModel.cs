using CursoMVC_DDD.Domain.Entities;
using CursoMVC_DDD.Domain.ValueTypes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC_DDD.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos {1} caracteres")]
        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, 10, ErrorMessage = "Escreva um valor de {1} a {2}")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DataType(DataType.Currency)]        
        [Range(typeof(decimal), "0", "999999999", ErrorMessage = "Escreva um valor válido")]
        public decimal Valor { get; set; }

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int CategoriaId { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }
    }
}
