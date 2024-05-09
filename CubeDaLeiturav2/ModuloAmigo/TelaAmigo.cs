using CubeDaLeiturav2.Compartilhado;

namespace CubeDaLeiturav2.ModuloAmigo
{
    public class TelaAmigo
    {
        TelaBase tela = new TelaBase();
        RepositorioAmigo RAmigo = new RepositorioAmigo();
        public void Cadastro()
        {
            tela.Cabecalho();
            Console.Write("\tCadastro de Amigo");

            Console.Write("\n\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("\nNome do responsavel: ");
            string nomeResponsavel = Console.ReadLine();
            long telefone = tela.LerLong("\nTelefone: ");
            Console.Write("\nDigite seu endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            RAmigo.Salvar(amigo);

            tela.CadastroComSucesso();
        }

        public void Multa()
        {

        }
    }
}
