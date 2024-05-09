namespace CubeDaLeiturav2.ModuloRevista
{
    public class Revista
    {
        public string Titulo { get; set; }
        public string Numero { get; set; }
        public string DataAno { get; set; }

        public Revista(string titulo, string numero, string dataAno)
        {
            Titulo = titulo;
            Numero = numero;
            DataAno = dataAno;
        }
    }
}
