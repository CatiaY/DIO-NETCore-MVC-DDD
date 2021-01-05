using System.Collections.Generic;
using Flunt.Validations;

namespace CursoMVC_DDD.Domain.ValueTypes
{
    public class Descricao
    {
        private readonly string _descricao;

        public readonly Contract contract;

        public Descricao(string descricao)
        {
            _descricao = descricao;
            
            contract = new Contract();

            Validar();                
        }

        public override string ToString() =>
            _descricao;

        public static implicit operator Descricao(string descricao) =>
            new Descricao(descricao);

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(_descricao))
                return AdicionarErro("Informe uma descrição válida.");

            if (_descricao.Length < 5)
                return AdicionarErro("A descrição deve ter mais de 5 caracteres");

            return true;
        }

        private bool AdicionarErro(string erro)
        {
            contract.AddNotification(nameof(Descricao), erro);
            return false;
        }
    }
}
