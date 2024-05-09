namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos { get; set; } = new Emprestimo[56];

        public Emprestimo[] Leitura()
        {
            return emprestimos;
        }
        public void Salvar(Emprestimo emprestimo)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                {
                    emprestimos[i] = emprestimo;
                }
            }
        }
    }
}
