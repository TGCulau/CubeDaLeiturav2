namespace CubeDaLeiturav2.ModuloAmigo
{
    internal class RepositorioAmigo
    {
        public Amigo[] amigos { get; set; } = new Amigo[43];

        public Amigo[] Leitura()
        {
            return amigos;
        }
        public void Salvar(Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                {
                    amigos[i] = amigo;
                }
            }
        }
    }
}
