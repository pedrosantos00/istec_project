using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IP
{
    public class Jogador
    {
        public string Nome { get; set; }
        public bool EstaEmJogo { get; set; } = false;
        public int TotalJogos { get; set; } = 0;
        public int TotalVitorias { get; set; } = 0;
        public int PecasEspeciaisDisponveis { get; set; } = 0;
        public Jogador() { }
        public Jogador(string nome)
        {
            Nome = nome;
        }
        public Jogador(string nome, int totalJogos)
        {
            Nome = nome;
            TotalJogos = totalJogos;
        }
        public Jogador(string nome, int totalJogos , int totalVitorias)
        {
            Nome = nome;
            TotalJogos = totalJogos;
            TotalVitorias = totalVitorias;
        }
    }
}
