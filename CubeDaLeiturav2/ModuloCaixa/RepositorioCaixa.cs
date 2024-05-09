namespace CubeDaLeiturav2.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[][] caixas { get; set; } = new Caixa[13][];

        public Caixa[][] Leitura()
        {
            return caixas;
        }
        public void Salvar(Caixa[] caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                {
                    caixas[i] = caixa;
                }
            }
        }
    }
}
