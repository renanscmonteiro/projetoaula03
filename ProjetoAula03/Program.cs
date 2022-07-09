using ProjetoAula03.Controllers;

namespace ProjetoAula03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pessoaController = new PessoaController();

            pessoaController.SistemaPessoas();

             Console.ReadKey();
        }
    }
}