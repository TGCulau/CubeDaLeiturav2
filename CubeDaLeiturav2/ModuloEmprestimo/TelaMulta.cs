using CubeDaLeiturav2.Compartilhado;
using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloCaixa;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class TelaMulta
    {
        #region Caixa de objetos

        #region Telas
        TelaBase tela = new TelaBase();
        TelaCaixa telaCaixa = new TelaCaixa();
        TelaAmigo telaAmigo = new TelaAmigo();
        TelaRevista telaRevista = new TelaRevista();
        TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
        #endregion

        #region Repositorios
        RepositorioCaixa RCaixa = new RepositorioCaixa();
        RepositorioRevista RRevista = new RepositorioRevista();
        RepositorioAmigo RAmigo = new RepositorioAmigo();
        RepositorioEmprestimo REmprestimo = new RepositorioEmprestimo();
        #endregion
        #endregion
        public void Menu()
        {
            telaEmprestimo.ChecagemDeDados();
            while (true)
            {
                tela.Cabecalho();
                Console.Write("\tMultas");
                int opMenu = tela.LerInt("\n1. Verficar Multas\n2. Quitar Multas\nSua Opção: ");
                if (opMenu != 1 && opMenu != 2)
                {
                    tela.Erro();
                    continue;
                }
                switch (opMenu)
                {
                    case 1:
                        VerficarUsuariosMultados();
                        continue;
                    case 2:
                        QuitarMultas();
                        break;
                }
                break;
            }

        }

        public void VerficarUsuariosMultados()
        {
            tela.Cabecalho();
            Console.Write("\tVerificar Multas");
            Console.Write("\n\nLista de usuarios com multa em aberto");

            Amigo[] amigo = RAmigo.Leitura();

            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i].EstaMultado)
                {
                    Console.Write($"\n Nome {amigo[i].Nome} | Nome do Responsavel {amigo[i].NomeResponsavel} | Telefone {amigo[i].Telefone} | Enbdereço {amigo[i].Endereco} |");
                }
            }
            Console.Write("\n\nPrecione qualquer tecla para retornar ao menu anterior.");
            Console.ReadKey();
        }
        public void QuitarMultas()
        {
            tela.Cabecalho();
            Console.Write("\tQuitar Multas");
            Console.Write("\n\nLista de usuarios com multa em aberto");

            Amigo[] amigo = RAmigo.Leitura();

            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i].EstaMultado)
                {
                    Console.Write($"\n ID {i} | Nome {amigo[i].Nome}");
                }
            }
            int idAmigo = tela.LerInt("\nDigite o ID do amigo correspondente para o imprestimo: ");
            amigo[idAmigo].EstaMultado = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\nO amigo {amigo[idAmigo].Nome} não está mais multado :D\nPrecione qualque tecla para continuar.");
            Console.ReadKey();
        }
        public void AplicarMultaAltomatica()
        {
            List<Emprestimo> emprestimos = REmprestimo.Leitura();
            DateTime dataDeAgora = DateTime.Now;

            int idCaixa = -1;
            foreach (Emprestimo emprestimo in emprestimos)
            {
                idCaixa++;
                if (dataDeAgora > emprestimos[idCaixa].DataDevolucao)
                {
                    emprestimos[idCaixa].Amigo.EstaMultado = true;
                }
            }
        }
    }
}
