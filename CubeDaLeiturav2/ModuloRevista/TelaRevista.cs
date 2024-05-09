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

            Revista revista = new Revista(titulo, numero, dataAno);

            RRevista.Salvar(revista);

            tela.CadastroComSucesso();
        }
        public void Editar()
        {

        }

        public void Reservas()
        {

        }
    }
}
