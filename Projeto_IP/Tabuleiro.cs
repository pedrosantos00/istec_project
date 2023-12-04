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
        public bool VezJogador { get; set; } = false; // FALSO É JOGADOR1 , TRUE É JOGADOR2
        public int SequenciaParaGanhar { get; set; }
        public int TamanhoPecaEspecial { get; set; }
        public int[,] Jogo { get; set; }
    }
}
