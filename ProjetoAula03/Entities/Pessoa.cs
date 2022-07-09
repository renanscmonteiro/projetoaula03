using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAula03.Validations;

namespace ProjetoAula03.Entities
{
    /// <summary>
    /// Classe de entidade
    /// </summary>
    public class Pessoa
    {
        #region Atributos
        private Guid _idPessoa;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;
        #endregion

        #region Propriedades
        public Guid IdPessoa
        {
            // Utlizando expressão LAMBDA no retorno de valores no método Set
            //get { return _idPessoa; }
            get => _idPessoa; // Exemplo de sintaxe LAMBDA "=>" para retornar o _idPessoa;

            set
            {
                if (!IdValidation.IsValid(value))
                    throw new ArgumentException("O ID da pessoa é inválido.");

                _idPessoa = value;
            }
        }
        public string Nome
        {
            get => _nome;
            set
            {
                if (!NomeValidation.IsValid(value))
                    throw new ArgumentException("O nome da pessoa é inválido.");
                _nome = value;
            }
        }
        public string Cpf
        {
            get => _cpf;
            set
            {
                if (!CpfValidation.IsValid(value))
                    throw new ArgumentException("O CPF da pessoa é inválido.");
                _cpf = value;
            }
        }
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                if (!DataValidation.IsValid(value))
                    throw new ArgumentException("A data de nascimento da pessoa é inválida.");
                _dataNascimento = value;
            }
        }
        #endregion
    }
}