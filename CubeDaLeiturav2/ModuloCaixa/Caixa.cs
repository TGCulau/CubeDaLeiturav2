using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloCaixa
{
    public class Caixa
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }
        public List<Revista> Revistas { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
            Revistas = new List<Revista>();
        }
    }
}
