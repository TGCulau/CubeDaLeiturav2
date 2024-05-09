namespace CubeDaLeiturav2.ModuloRevista
{
    public class RepositorioRevista
    {
        public Revista[] revistas { get; set; } = new Revista[56];

        public Revista[] Leitura()
        {
            return revistas;
        }
        public void Salvar(Revista revista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                {
                    revistas[i] = revista;
                }
            }
        }
    }
}
