namespace CubeDaLeiturav2.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public List<Caixa> caixas { get; set; } = new List<Caixa>();

        public List<Caixa> Leitura()
        {
            return caixas;
        }
        public void Salvar(Caixa caixa)
        {
            caixas.Add(caixa);
        }
        public void SalvarLista(List<Caixa> caixas)
        {
            this.caixas = caixas;
        }
    }
}
