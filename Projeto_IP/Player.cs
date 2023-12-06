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
        public bool IsInGame { get; set; } = false;
        public int TotalWins { get; set; } = 0;
        public int TotalLoses { get; set; } = 0;
        public int TotalDraws { get; set; } = 0;
        public int EspecialPiecesAvaiable { get; set; } = 0;
        public Player() { }
        public Player(string nome)
        {
            Name = nome;
        }
       
        public Player(string nome ,int totalVitorias)
        {
            Name = nome;
            TotalWins = totalVitorias;
        }

        public Player(string name,int totalWins, int totalLoses, int totalDraws) : this(name)
        {
            TotalWins = totalWins;
            TotalLoses = totalLoses;
            TotalDraws = totalDraws;
        }

        public int TotalGames()
        {
            return TotalWins + TotalDraws + TotalLoses;
        }
    }
}
