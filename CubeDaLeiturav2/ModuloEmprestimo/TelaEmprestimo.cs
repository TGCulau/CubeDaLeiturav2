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



            //carregando objetos
            List<Caixa> caixas = RCaixa.Leitura();
            Amigo[] amigo = RAmigo.Leitura();

            tela.Cabecalho();

            Console.Write("\tCadastro de emprestimo");

            Console.Write("\n\tLista de amigos cadastrados");

            for (int i = 0; i < amigo.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {amigo[i].Nome}");
            }

            int idAmigo = tela.LerInt("\nDigite o ID do amigo correspondente para o imprestimo: ");

            int idCaixa = -1;
            foreach (Caixa caixa in caixas)
            {
                idCaixa++;
                Console.WriteLine($"ID {idCaixa} | Etiqueta: {caixa.Etiqueta} | Cor: {caixa.Cor} | Dias de Empréstimo: {caixa.DiasEmprestimo}");
            }
            idCaixa = tela.LerInt("\nDigite o ID da caixa desejada: ");

            if (idCaixa >= 0 && idCaixa < caixas.Count)
            {
                Caixa caixaEscolhida = caixas[idCaixa];
                foreach (Revista revista in caixaEscolhida.Revistas)
                {
                    Console.WriteLine($"\tTítulo: {revista.Titulo}, Número da Edição: {revista.NumeroEdicao}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, tente novamente.");
            }
            idCaixa = tela.LerInt("\nDigite o ID da revista desejada: ");

            Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo, revista[id]);

            RCaixa.Salvar(caixa);

            tela.CadastroComSucesso();
        }
    }
}
