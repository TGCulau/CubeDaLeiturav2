using CubeDaLeiturav2.Compartilhado;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloCaixa
{
    public class TelaCaixa
    {
        #region Caixa de objetos
        TelaBase tela = new TelaBase();
        TelaRevista telaRevista = new TelaRevista();
        RepositorioCaixa RCaixa = new RepositorioCaixa();
        RepositorioRevista RRevista = new RepositorioRevista();
        #endregion
        public void Cadastro()
        {
            ChecagemRevista();

            tela.Cabecalho();

            Console.Write("\tCadastro de caixa");

            Console.Write("\nEtiqueta: ");
            string etiqueta = Console.ReadLine();
            Console.Write("\nCor: ");
            string cor = Console.ReadLine();
            int diasEmprestimo = tela.LerInt("\nQuantos dias de emprestimo essa caixa terá: ");

            Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo);

            RCaixa.Salvar(caixa);

            tela.CadastroComSucesso();

            CadastroDeRevista();
        }
        public void Editar()
        {
            Checagem();
            List<Caixa> caixas = RCaixa.Leitura();

            tela.Cabecalho();
            Console.Write("\n\tSelecionar caixa");

            for (int i = 0; i < caixas.Count; i++)
            {
                Console.Write($"\nID {i} | Etiqueta: {caixas[i].Etiqueta} | Cor: {caixas[i].Cor}");
            }
            int opCaixa = tela.LerInt("\nDigite a ID da caixa que voce deseja editar: ");

            tela.Cabecalho();
            Console.Write("\n\tEditar caixa");
            Console.Write($"\nAtualmente a etiqueta está cadastrada como {caixas[opCaixa].Etiqueta}. Digite a nova etiqueta: ");
            caixas[opCaixa].Etiqueta = Console.ReadLine();
            Console.Write($"\nAtualmente a cor está cadastrada como {caixas[opCaixa].Cor}. Digite a nova cor: ");
            caixas[opCaixa].Cor = Console.ReadLine();
            caixas[opCaixa].DiasEmprestimo = tela.LerInt($"\nAtualmente os dias de empréstimo estão cadastrados como {caixas[opCaixa].DiasEmprestimo}. Digite os novos dias de empréstimo: ");

            tela.CadastroComSucesso();

            RCaixa.SalvarLista(caixas);
        }
        public void CadastroDeRevista()
        {
            ChecagemRevista();

            Revista[] revista = RRevista.Leitura();

            tela.Cabecalho();
            Console.Write("\n\tLista de revistas cadastradas");

            for (int i = 0; i < revista.Length; i++)
            {
                Console.Write($"\nID {i} | Titulo {revista[i].Titulo}");
            }

            int id = tela.LerInt("\nDigite o ID da revista desejada: ");

            List<Caixa> caixas = RCaixa.Leitura();
            int idCaixa = -1;
            foreach (Caixa caixa in caixas)
            {
                idCaixa++;
                Console.WriteLine($"ID {idCaixa} | Etiqueta: {caixa.Etiqueta} | Cor: {caixa.Cor} | Dias de Empréstimo: {caixa.DiasEmprestimo}");
            }

            idCaixa = tela.LerInt("\nDigite o ID da caixa desejada: ");

            caixas[idCaixa].Revistas.Add(revista[id]);
            tela.CadastroComSucesso();

            RCaixa.SalvarLista(caixas);
        }
        public void ChecagemRevista()
        {
            Revista[] revista = RRevista.Leitura();
            int cont = 0;
            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i] == null)
                {
                    cont++;
                }
            }
            if (revista.Length == cont)
            {
                tela.ErroNaChecagem();
                Console.Write("\nNenhuma revista cadastrada ainda, você será redirecionado ao cadastro de revistas e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                telaRevista.Cadastro();
            }
        }
        public void Checagem()
        {
            List<Caixa> caixas = RCaixa.Leitura();
            tela.Cabecalho();

            if (caixas.Count == 0)
            {
                tela.ErroNaChecagem();
                Console.Write("\nNenhuma caixa cadastrada ainda, você será redirecionado ao cadastro de caixas e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                Cadastro();
            }
        }
    }
}
