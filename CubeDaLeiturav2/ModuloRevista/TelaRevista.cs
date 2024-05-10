using CubeDaLeiturav2.Compartilhado;

namespace CubeDaLeiturav2.ModuloRevista
{
    public class TelaRevista
    {
        TelaBase tela = new TelaBase();
        RepositorioRevista RRevista = new RepositorioRevista();
        public void Cadastro()
        {
            tela.Cabecalho();
            Console.Write("\tCadastro de Revista");

            Console.Write("\nTitulo: ");
            string titulo = Console.ReadLine();
            Console.Write("\nNumero da edição: ");
            string numero = Console.ReadLine();
            Console.Write("\nAno: ");
            string dataAno = Console.ReadLine();
            bool estaReservada = false;

            Revista revista = new Revista(titulo, numero, dataAno, estaReservada);

            RRevista.Salvar(revista);

            tela.CadastroComSucesso();
        }
        public void Editar()
        {
            Revista[] revista = RRevista.Leitura();
            tela.Cabecalho();
            Console.Write("\n\tSelecionar Revista");

            for (int i = 0; i < revista.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {revista[i].Titulo}");
            }
            int oprevista = tela.LerInt("\nDigite a ID da revista que voce deseja editar: ");

            tela.Cabecalho();

            Console.Write("\n\tEditar amigo");
            Console.Write($"\nAtualmente o nome está cadastrado como {revista[oprevista].Titulo}. Digite o novo nome: ");
            revista[oprevista].Titulo = Console.ReadLine();
            Console.Write($"\nAtualmente o numero da edição cadastrado é {revista[oprevista].Numero}. Digite o novo numero da edição: ");
            revista[oprevista].Numero = Console.ReadLine();
            Console.Write($"\nAtualmente o ano da edição cadastrado é {revista[oprevista].DataAno}. Digite o novo ano da edição: ");
            revista[oprevista].DataAno = Console.ReadLine();

            tela.CadastroComSucesso();
        }
        public void Reservas()
        {
            Revista[] revista = RRevista.Leitura();
            tela.Cabecalho();
            Console.Write("\n\tSelecionar Revista");

            for (int i = 0; i < revista.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {revista[i].Titulo}");
            }
            while (true)
            {
                int idrevista = tela.LerInt("\nDigite a ID da revista que voce deseja reservar?: ");
                if (idrevista < 0 || idrevista > revista.Length)
                {
                    continue;
                }
                revista[idrevista].EstaReservada = true;
                RRevista.Salvar(revista[idrevista]);
                break;
            }

            tela.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Reserva efetuada com sucesso!\n\nPrecione qualquer tecla para continuar.");
            Console.ResetColor();
        }
    }
}
