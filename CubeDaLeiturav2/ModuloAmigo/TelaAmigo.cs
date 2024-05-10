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
            bool estaMultado = false;

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco, estaMultado);

            RAmigo.Salvar(amigo);

            tela.CadastroComSucesso();
        }
        public void Editar()
        {
            Checagem();
            Amigo[] amigo = RAmigo.Leitura();
            tela.Cabecalho();
            Console.Write("\n\tSelecionar amigo");

            for (int i = 0; i < amigo.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {amigo[i].Nome}");
            }
            int opamigo = tela.LerInt("\nDigite a ID do amigo que voce deseja editar: ");

            tela.Cabecalho();
            Console.Write("\n\tEditar amigo");
            Console.Write($"\nAtualmente o nome está cadastrado como {amigo[opamigo].Nome}. Digite o novo nome: ");
            amigo[opamigo].Nome = Console.ReadLine();
            Console.Write($"\nAtualmente o nome do responsavel está cadastrado como {amigo[opamigo].NomeResponsavel}. Digite o novo nome: ");
            amigo[opamigo].NomeResponsavel = Console.ReadLine();
            amigo[opamigo].Telefone = tela.LerInt($"\nAtualmente o telefone cadastrado é {amigo[opamigo].Telefone}. Digite o novo telefone: ");
            Console.Write($"\nAtualmente o endereço está cadastrado como {amigo[opamigo].Endereco}. Digite o novo endereço: ");
            amigo[opamigo].Endereco = Console.ReadLine();

            tela.CadastroComSucesso();
        }
        public void Checagem()
        {
            Amigo[] amigo = RAmigo.Leitura();
            tela.Cabecalho();
            int cont = 0;
            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i] == null)
                {
                    cont++;
                }
            }
            if (amigo.Length == cont)
            {
                tela.ErroNaChecagem();
                Console.Write("\nNenhum amigo cadastrado ainda, você será redirecionado ao cadastro de amigos e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                Cadastro();
            }
        }
    }
}
