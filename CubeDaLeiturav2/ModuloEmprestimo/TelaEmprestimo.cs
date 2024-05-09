using CubeDaLeiturav2.Compartilhado;
using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloCaixa;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        #region Caixa de objetos
        TelaBase tela = new TelaBase();
        TelaCaixa telaCaixa = new TelaCaixa();
        TelaAmigo telaAmigo = new TelaAmigo();
        RepositorioCaixa RCaixa = new RepositorioCaixa();
        RepositorioRevista RRevista = new RepositorioRevista();
        RepositorioAmigo RAmigo = new RepositorioAmigo();
        #endregion
        public void Cadastro()
        {
            telaCaixa.ChecagemRevista();
            ChecagemAmigo();

            Caixa[] caixa = RCaixa.Leitura();
            Amigo[] amigo = RAmigo.Leitura();

            tela.Cabecalho();

            Console.Write("\tCadastro de emprestimo");

            Console.Write("\n\tLista de amigos cadastrados");

            for (int i = 0; i < amigo.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {amigo[i].Nome}");
            }

            int idAmigo = tela.LerInt("\nDigite o ID do amigo correspondente para o imprestimo: ");

            Console.Write("\n\tLista de Caixas cadastradas");

            for (int i = 0; i < caixa.Length; i++)
            {
                Console.Write($"\nID {i} | Cor {caixa[i].Cor} | Etiqueta {caixa[i].Etiqueta}");
            }

            int idCaixa = tela.LerInt("\nDigite o ID da Revista desejada: ");

            Console.Write($"\nCaixa | Cor {caixa[idCaixa].Cor} | Etiqueta {caixa[idCaixa].Etiqueta}|\n");
            for (int i = 0; i < caixa.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {caixa[idCaixa].Revista[i]} |");
            }


            Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo, revista[id]);

            RCaixa.Salvar(caixa);

            tela.CadastroComSucesso();
        }

        public void ChecagemAmigo()
        {
            Amigo[] amigo = RAmigo.Leitura();
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
                Console.Write("\nNenhuma revista cadastrada ainda, você será redirecionado ao cadastro de revistas e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                telaAmigo.Cadastro();
            }
        }
    }
}
