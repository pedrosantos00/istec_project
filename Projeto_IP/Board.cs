using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IP
{
    public class Board
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool GameBeingPlayed { get; set; } = false;
        public int Length { get; set; }
        public int Width { get; set; }
        public int Sequence { get; set; }
        public int SpecialPiece { get; set; }
    }
}
