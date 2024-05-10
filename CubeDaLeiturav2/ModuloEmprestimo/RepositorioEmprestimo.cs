namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public List<Emprestimo> emprestimos { get; set; } = new List<Emprestimo>();

        public List<Emprestimo> Leitura()
        {
            return emprestimos;
        }
        public void Salvar(Emprestimo emprestimo)
        {
            emprestimos.Add(emprestimo);
        }
        public void SalvarLista(List<Emprestimo> emprestimo)
        {
            this.emprestimos = emprestimos;
        }
    }
}
