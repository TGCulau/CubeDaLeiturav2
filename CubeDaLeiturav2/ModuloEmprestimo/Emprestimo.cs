using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class Emprestimo
    {
        Amigo Amigo { get; set; }
        Revista Revista { get; set; }
        int DiaEmprestimo, MesEmprestimo, AnoEmprestimo, DiaDevolucao, MesDevolucao, AnoDevolucao;
        bool FoiEntregue;
        public Emprestimo(Amigo amigo, Revista revista, int diaEmprestimo, int mesEmprestimo, int anoEmprestimo, int diaDevolucao, int mesDevolucao, int anoDevolucao, bool foiEntregue)
        {
            Amigo = amigo;
            Revista = revista;
            DiaEmprestimo = diaEmprestimo;
            MesEmprestimo = mesEmprestimo;
            AnoEmprestimo = anoEmprestimo;
            DiaDevolucao = diaDevolucao;
            MesDevolucao = mesDevolucao;
            AnoDevolucao = anoDevolucao;
            FoiEntregue = foiEntregue;
        }
    }
}
