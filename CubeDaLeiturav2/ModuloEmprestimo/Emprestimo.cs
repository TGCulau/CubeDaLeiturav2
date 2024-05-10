﻿using CubeDaLeiturav2.ModuloAmigo;
using CubeDaLeiturav2.ModuloRevista;

namespace CubeDaLeiturav2.ModuloEmprestimo
{
    public class Emprestimo
    {
        Amigo Amigo { get; set; }
        Revista Revista { get; set; }
        string DataFormatada;
        int Prazo;
        DateTime DataEmprestimo, DataDevolucao;
        bool FoiEntregue;
        public Emprestimo(Amigo amigo, Revista revista, int prazo, string dataFormatada, DateTime dataEmprestimo, DateTime dataDevolucao, bool foiEntregue)
        {
            Amigo = amigo;
            Revista = revista;
            Prazo = prazo;
            DataFormatada = dataFormatada;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            FoiEntregue = foiEntregue;
        }
    }
}
