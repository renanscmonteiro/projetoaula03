using ProjetoAula03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;


namespace ProjetoAula03.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para pessoa
    /// </summary>
    public class PessoaRepository
    {
        #region Atributos
        private string _connectionString;
        #endregion

        #region Construtores
        public PessoaRepository()
        {
            // Inicialidando o valor do atributo com a connection string do DB
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBProjetoAula03;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        #endregion
        /// <summary>
        /// método para cadastrar pessoa no banco de dados
        /// </summary>
        public void Create(Pessoa pessoa)
        {
            // escrevendo uma query do tipo insert em sql
            var insert = @"
                INSERT INTO PESSOA (
                    IDPESSOA, 
                    NOME, 
                    CPF, 
                    DATANASCIMENTO)
                VALUES(
                    @IdPessoa, 
                    @Nome, 
                    @Cpf, 
                    @DataNascimento)
            ";

            // Abrindo a conexão com o banco de dados do SQL Server
            using (var connection = new SqlConnection(_connectionString))
            {
                //Executando o comando SQL
                connection.Execute(insert, pessoa);
            }
        }
        /// <summary>
        /// método para atualizar pessoa no banco de dados
        /// </summary>
        public void Update(Pessoa pessoa)
        {
            // escrevendo uma query do tipo update em sql
            var update = @"
                UPDATE PESSOA SET
                    NOME = @Nome,
                    CPF = @Cpf
                    DATANASCIMENTO = @DataNascimento
                WHERE 
                    IDPESSOA = @IdPessoa
            ";

            // Abrindo a conexão com o banco de dados do SQL Server
            using (var connection = new SqlConnection(_connectionString))
            {
                // Executando comando SQL
                connection.Execute(update, pessoa);
            }
        }
        /// <summary>
        /// método para excluir pessoa no banco de dados
        /// </summary>
        public void Delete(Pessoa pessoa)
        {
            // escrevendo uma query do tipo delete em sql
            var delete = @"
                DELETE FROM PESSOA 
                WHERE IDPESSOA = @IdPessoa
            ";

            // Abrindo a conexão com o banco de dados do SQL Server
            using (var connection = new SqlConnection(_connectionString))
            {
                // Executando comando SQL
                connection.Execute(delete, pessoa);
            }
        }
        /// <summary>
        /// método para ler uma lista de pessoas cadastradas no banco de dados
        /// </summary>
        public List<Pessoa> GetAll()
        {
            // escrevendo uma query do tipo select em sql
            var selectAll = @"
                SELECT * FROM PESSOA
                ORDER BY NOME
            ";

            // Abrindo a conexão com o banco de dados do SQL Server
            using (var connection = new SqlConnection(_connectionString))
            {
                // Executando comando SQL para retornar uma lista de pessoas
                return connection.Query<Pessoa>(selectAll).ToList();
            }
        }
        /// <summary>
        /// método para ler uma única pessoa cadastrada no banco de dados baseado no ID
        /// </summary>
        public Pessoa GetById(Guid idPessoa)
        {
            var selectById = @"
                SELECT * FROM PESSOA
                WHERE IDPESSOA = @idPessoa
            ";

            // Abrindo a conexão com o banco de dados do SQL Server
            using (var connection = new SqlConnection(_connectionString))
            {
                // Executando comando SQL para retornar um pessoa pelo ID
                return connection.Query<Pessoa>(selectById, new { idPessoa }).FirstOrDefault();
            }
        }
    }
}