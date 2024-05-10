using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class Emprestimo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public string DataFormatada;
        public int Prazo;
        public DateTime DataEmprestimo, DataDevolucao;
        public bool FoiEntregue;
        public Emprestimo(Amigo amigo, Revista revista, int prazo, string dataFormatada, DateTime dataEmprestimo, DateTime dataDevolucao, bool foiEntregue)
        {
            Amigo = amigo;
            Revista = revista;
            Prazo = prazo;
            DataFormatada = dataFormatada;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            FoiEntregue = foiEntregue;
        }
    }
}
