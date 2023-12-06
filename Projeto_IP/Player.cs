using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IP
{
    public class Player
    {
        public string Name { get; set; }
        public bool InGame { get; set; } = false;
        public int GameTotal { get; set; } = 0;
        public int VictoryTotal { get; set; } = 0;

        public Player() { }
        public Player(string name)
        {
            Name = name;
        }
        public Player(string name, int gameTotal)
        {
            Name = name;
            GameTotal = gameTotal;
        }
        public Player(string name, int gameTotal , int victoryTotal)
        {
            Name = name;
            GameTotal = gameTotal;
            VictoryTotal = victoryTotal;
        }
    }
}
