using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IP
{
    public class Tabuleiro
    {
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public bool JogoEmCurso { get; set; } = false;
        public int Comprimento { get; set; }
        public int Largura { get; set; }
        public int Sequencia { get; set; }
        public int PecaEspecial { get; set; }
    }
}
