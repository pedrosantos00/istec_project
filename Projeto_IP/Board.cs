using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IP
{
    public class Board
    {
        public Player Player1 { get; set; } = new Player();
        public Player Player2 { get; set; } = new Player();
        public bool InGame { get; set; } = false;
        public bool PlayerMove { get; set; } = false; // FALSO É JOGADOR1 , TRUE É JOGADOR2
        public int SequenceToWin { get; set; } = 0;
        public int SpecialPieceLenght { get; set; } = 0;
        public int[,] GameBoard { get; set; } = new int[0, 0];
    }
}
