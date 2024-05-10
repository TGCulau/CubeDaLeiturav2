using CubeDaLeiturav2.Compartilhado;
using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloCaixa;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        #region Caixa de objetos

        #region Telas
        TelaBase tela = new TelaBase();
        TelaCaixa telaCaixa = new TelaCaixa();
        TelaAmigo telaAmigo = new TelaAmigo();
        TelaRevista telaRevista = new TelaRevista();
        #endregion

        #region Repositorios
        RepositorioCaixa RCaixa = new RepositorioCaixa();
        RepositorioRevista RRevista = new RepositorioRevista();
        RepositorioAmigo RAmigo = new RepositorioAmigo();
        RepositorioEmprestimo REmprestimo = new RepositorioEmprestimo();
        #endregion
        #endregion

        public void Cadastro()
        {
            while (true)
            {
                ChecagemDeDados();

                //carregando objetos
                List<Caixa> caixas = RCaixa.Leitura();
                Amigo[] amigo = RAmigo.Leitura();

                tela.Cabecalho();

                Console.Write("\tCadastro de emprestimo");

                Console.Write("\n\tLista de amigos cadastrados");

                for (int i = 0; i < amigo.Length; i++)
                {
                    Console.Write($"\nID {i} | Nome {amigo[i].Nome}");
                }
                int idAmigo = tela.LerInt("\nDigite o ID do amigo correspondente para o imprestimo: ");
                if (amigo[idAmigo].EstaMultado)
                {
                    tela.UsuarioMultado();
                    continue;
                }

                int idCaixa = -1;
                foreach (Caixa caixa in caixas)
                {
                    idCaixa++;
                    Console.WriteLine($"ID {idCaixa} | Etiqueta: {caixa.Etiqueta} | Cor: {caixa.Cor} | Dias de Empréstimo: {caixa.DiasEmprestimo}");
                }
                idCaixa = tela.LerInt("\nDigite o ID da caixa desejada: ");

                int idRevista = -1;
                if (idCaixa >= 0 && idCaixa < caixas.Count)
                {
                    foreach (Revista revista in caixas[idCaixa].Revistas)
                    {
                        idCaixa++;
                        if (revista.EstaReservada == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\tID {idCaixa} | Título: {revista.Titulo} | Número da Edição: {revista.Numero} | Esta revista está reservada!");
                            Console.ResetColor();
                        }
                        Console.WriteLine($"\tID {idCaixa} | Título: {revista.Titulo} | Número da Edição: {revista.Numero}");
                    }
                }
                idRevista = tela.LerInt("\nDigite o ID da revista desejada: ");

                if (caixas[idCaixa].Revistas[idRevista].EstaReservada == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    while (true)
                    {
                        int opReserva = tela.LerInt("\nEstá revista não pode ser emprestada, pois ela está reservada. Vá ao menu 'Reservas' para alterar o status dela\nGostaria de ir para o menu Reservas agora?\n1. Sim\n2. Não\nSua opção: ");
                        if (opReserva != 1 && opReserva != 2)
                        {
                            continue;
                        }
                        switch (opReserva)
                        {
                            case 1:
                                telaRevista.Reservas();
                                break;
                            case 2:
                                break;
                        }
                    }
                }
                tela.Cabecalho();
                Console.Write("\tCadastro de emprestimo");
                int prazo = tela.LerInt("Digite quantos dias será emprestada essa revista: ");

                //salva a data formatada em string pra ficar bonito na impressão
                string dataFormatada = DateTime.Now.ToShortDateString();

                //Pega a data do sistema
                DateTime dataEmprestimo = DateTime.Now;

                //calcula o prazo
                DateTime dataDevolucao = dataEmprestimo.AddDays(prazo);

                bool foiEntregue = false;

                Emprestimo emprestimo = new Emprestimo(amigo[idAmigo], caixas[idCaixa].Revistas[idRevista], prazo, dataFormatada, dataEmprestimo, dataDevolucao, foiEntregue);

                REmprestimo.Salvar(emprestimo);
                tela.CadastroComSucesso();
                break;
            }

        }
        public void ChecagemDeDados()
        {
            telaAmigo.Checagem();
            telaCaixa.Checagem();
        }

    }
}
