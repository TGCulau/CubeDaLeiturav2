namespace CubeDaLeiturav2.ModuloAmigo
{
    public class Amigo
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public long Telefone { get; set; }
        public string Endereco { get; set; }

        public Amigo(string nome, string nomeResponsavel, long telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
