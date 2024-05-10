using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloCaixa;
using CubeDaLeiturav2.ModuloEmprestimo;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.Compartilhado
{
    public class TelaBase
    {
        public void MenuPrincipal()
        {
            while (true)
            {
                Cabecalho();
                int opmenu = LerInt("Escolha uma opção no menu\n1. Adicionar ou editar cadastro\n2. Gerenciamento\nSua Opção:");
                if (opmenu != 1 && opmenu != 2)
                {
                    Erro();
                    continue;
                }
                switch (opmenu)
                {
                    case 1:
                        Cadastro();
                        break;

                    case 2:
                        Gerenciamento();
                        break;
                }
            }
        }
        public void Cadastro()
        {
            TelaAmigo amigo = new TelaAmigo();
            TelaRevista revista = new TelaRevista();
            TelaCaixa caixa = new TelaCaixa();

            while (true)
            {
                Cabecalho();
                int opmenu = LerInt("Escolha uma opção\n1. Editar\n2. Cadastrar\nSua Opção: ");
                if (opmenu != 1 && opmenu != 2)
                {
                    Erro();
                    continue;
                }
                switch (opmenu)
                {
                    case 1:
                        while (true)
                        {
                            int submenu = LerInt("Escolha uma opção:\n1. Amigo\n2. Revista\n3. Caixa\nSua Opção: ");
                            if (opmenu != 1 && opmenu != 2 && opmenu != 3)
                            {
                                Erro();
                                continue;
                            }
                            switch (submenu)
                            {
                                case 1:
                                    amigo.Editar();
                                    break;
                                case 2:
                                    revista.Editar();
                                    break;
                                case 3:
                                    caixa.Editar();
                                    break;
                            }
                            break;
                        }
                        break;

                    case 2:
                        {
                            while (true)
                            {
                                int submenu = LerInt("Escolha uma opção:\n1. Amigo\n2. Revista\n3. Caixa\nSua Opção: ");
                                if (opmenu != 1 && opmenu != 2 && opmenu != 3)
                                {
                                    Erro();
                                    continue;
                                }
                                switch (submenu)
                                {
                                    case 1:
                                        amigo.Cadastro();
                                        break;
                                    case 2:
                                        revista.Cadastro();
                                        break;
                                    case 3:
                                        caixa.Cadastro();
                                        break;
                                }
                                break;
                            }
                            break;
                        }
                }
            }
        }

        public void Gerenciamento()
        {
            TelaAmigo amigo = new TelaAmigo();
            TelaRevista revista = new TelaRevista();
            TelaEmprestimo emprestimo = new TelaEmprestimo();

            while (true)
            {
                Cabecalho();
                int opmenu = LerInt("Escolha uma opção\n1. Emprestimo\n2. Reservas\n3. Multa\nSua Opção: ");
                if (opmenu != 1 && opmenu != 2 && opmenu != 3)
                {
                    Erro();
                    continue;
                }
                switch (opmenu)
                {
                    case 1:
                        emprestimo.Cadastro();
                        break;
                    case 2:
                        revista.Reservas();
                        break;
                    case 3:
                        amigo.Multa();
                        break;
                }
            }
        }


        public int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);
                if (digitouNumero)
                {
                    return numero;
                }
                Erro();
            }
        }
        public void Erro()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                               Comando inválido. Por favor digite um comando válido.                              ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ReadKey();
            Cabecalho();
        }
        public void ErroNaChecagem()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                              Nenhum dado localizado!                                             ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################\n");
            Console.ResetColor();
        }
        public void CadastroComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Cadastro efetuado com sucesso!\n\nPrecione qualquer tecla para continuar.");
            Console.ResetColor();
        }
        public long LerLong(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = long.TryParse(Console.ReadLine(), out var numero);
                if (digitouNumero)
                {
                    return numero;
                }
                Erro();
            }
        }
        public void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                 Clube da Leitura                                                 ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                    Marea Turbo                                                   ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################\n");
            Console.ResetColor();
        }
    }
}
