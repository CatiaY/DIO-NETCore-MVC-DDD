using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models
{
    public class Categoria
    {
        // Obs.: O projeto implementa o modelo Code First
        public int Id { get; set; }  // Será a chave primária da tabela

        [Display (Name = "Descrição")]
        [Required (ErrorMessage = "Este campo é obrigatório!")]
        public string Descricao { get; set; }

        // Lista de produtos: Foi removida pois ocasionará erro de referência, já que o produto já faz refrência à classe Categoria
        // public List<Produto> Produtos { get; set; }
    }
}