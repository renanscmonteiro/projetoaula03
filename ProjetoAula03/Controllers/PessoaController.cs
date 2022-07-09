using ProjetoAula03.Entities;
using ProjetoAula03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Controllers
{
    /// <summary>
    /// Classe de controle para operações de pessoa
    /// </summary>
    public class PessoaController
    {
        // Método para iniciar o Sistema de pessoas
        public void SistemaPessoas()
        {
            try
            {
                Console.WriteLine("\n *** Sistema de controle de pessoas ***");

                Console.WriteLine("(1) Cadastrar pessoa");
                Console.WriteLine("(2) Atualizar pessoa");
                Console.WriteLine("(3) Excluir pessoa");
                Console.WriteLine("(4) Consultar pessoa");

                Console.Write("Informe a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                var pessoaController = new PessoaController();

                switch (opcao)
                {
                    case 1:
                        pessoaController.CadastrarPessoa();
                        break;
                    case 2:
                        pessoaController.AtualizarPessoa();
                        break;
                    case 3:
                        pessoaController.ExcluirPessoa();
                        break;
                    case 4:
                        pessoaController.ListarPessoas();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha: {e.Message}");
            }
            finally
            {
                if (RepetirProcesso())
                {
                    Console.Clear();
                    SistemaPessoas(); // recursividade
                }
            }
        }
        // Método para cadastrar uma pessoa no Banco de dados
        private void CadastrarPessoa()
        {
            try
            {
                Console.WriteLine("\n *** Cadastro de pessoa ***");
                // Obtendo os dados via console
                var pessoa = new Pessoa();
                pessoa.IdPessoa = Guid.NewGuid();

                Console.Write("Digite o nome de pesssoa.................: ");
                pessoa.Nome = Console.ReadLine();
                Console.Write("Digite o CPF da pessoa...................: ");
                pessoa.Cpf = Console.ReadLine();
                Console.Write("Digite a data de nascimento da pessoa....: ");
                pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());

                //gravando os dados no banco
                var pessoaRepository = new PessoaRepository();
                pessoaRepository.Create(pessoa);

                Console.WriteLine("\nPessoa cadastrada com sucesso");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nFalha de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar: {e.Message}");
            }
            finally
            {
                if (RepetirProcesso())
                {
                    Console.Clear();
                    CadastrarPessoa(); // recursividade
                }
            }
        }

        // Método para atualizar um registro no banco de dados
        private void AtualizarPessoa()
        {
            try
            {
                Console.WriteLine("\n *** Atualização de pessoa ***");
                // Obtendo os dados via console
                Console.Write("Digite o Id da pesssoa.................: ");
                var idPessoa = Guid.Parse(Console.ReadLine());

                // Consultando pessoa através do ID
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(idPessoa);

                // Verificar se o registro foi encontrado
                if (pessoa == null)
                    throw new NullReferenceException("O ID informado não existe no banco de dados");

                var desejaAtualizar = false;

                Console.Write("\nDeseja alterar o Nome? (S,N).....:");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe o Nome.....:");
                    pessoa.Nome = Console.ReadLine();
                }

                Console.Write("\nDeseja alterar o CPF? (S,N).....:");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe o CPF.....:");
                    pessoa.Cpf = Console.ReadLine();
                }

                Console.Write("\nDeseja alterar o Data Nasc? (S,N).....:");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe a Data Nasc.....:");
                    pessoa.DataNascimento = DateTime.Parse(Console.ReadLine());
                }

                //Atualizando os dados
                pessoaRepository.Update(pessoa);

                Console.WriteLine("\nPessoa atualizada com sucesso!");

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"\nFalha ao buscar id: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nFalha de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if (RepetirProcesso())
                {
                    Console.Clear();
                    AtualizarPessoa(); // recursividade
                }
            }
        }

        // Método para excluir um registro no banco de dados
        private void ExcluirPessoa()
        {
            try
            {
                Console.WriteLine("\n *** Exclusão de pessoa ***");
                // Obtendo os dados via console
                Console.Write("Digite o Id da pesssoa.................: ");
                var idPessoa = Guid.Parse(Console.ReadLine());

                // Consultando pessoa através do ID
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(idPessoa);

                if (pessoa == null)
                    throw new NullReferenceException("O ID informado não existe no banco de dados !");

                //Excluindo o dado
                pessoaRepository.Delete(pessoa);

                Console.WriteLine("\nPessoa excluida com sucesso!");

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"\nFalha ao buscar id: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao Excluir: {e.Message}");
            }
            finally
            {
                if (RepetirProcesso())
                {
                    Console.Clear();
                    ExcluirPessoa(); // recursividade
                }
            }
        }

        // Método para retornar uma lista no banco de dados
        private void ListarPessoas()
        {
            try
            {
                Console.WriteLine("\n *** Listar pessoas no banco de dados ***");

                var pessoaRepository = new PessoaRepository();
                var pessoas = pessoaRepository.GetAll();

                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine($"ID PESSOA.....................: {pessoa.IdPessoa}");
                    Console.WriteLine($"Nome..........................: {pessoa.Nome}");
                    Console.WriteLine($"CPF...........................: {pessoa.Cpf}");
                    Console.WriteLine($"Data de nascimento............: {pessoa.DataNascimento.ToString("dd/MM/yyyy")}");
                    Console.WriteLine("................................");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao Excluir: {e.Message}");
            }
            finally
            {
                if (RepetirProcesso())
                {
                    Console.Clear();
                    ListarPessoas(); // recursividade
                }
            }
        }


        // Método para verificar se o usuário deseja repetir o processo
        private bool RepetirProcesso()
        {
            Console.Write("\nDeseja repetir o processo? (S,N): ");
            var opcao = Console.ReadLine();

            return opcao != null && opcao.Equals("S", StringComparison.OrdinalIgnoreCase);
        }
    }
}