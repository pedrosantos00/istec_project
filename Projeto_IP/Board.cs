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

        // Verifica se há um vencedor ou um empate
        public int CheckForWinOrDraw()
        {
            // Verifica se algum jogador ganhou
            if (CheckRowsForWin() || CheckColumnsForWin() || CheckDiagonalsForWin())
            {
                UpdateScores(); // Atualiza os scores dos jogadores
                return 1; // Indica vitória
            }

            // Verifica se o jogo é um empate
            if (IsBoardFull())
            {
                Player1.TotalDraws++;
                Player2.TotalDraws++;
                return 2; // Indica empate
            }

            return 0; // Continua o jogo
        }

        // Verifica se há uma vitória nas diagonais
        private bool CheckDiagonalsForWin()
        {
            return CheckMajorDiagonalsForWin() || CheckMinorDiagonalsForWin();
        }

        // Atualiza os scores após uma vitória
        private void UpdateScores()
        {
            if (PlayerMove) // Se Player2 (O) venceu
            {
                Player2.TotalWins++;
                Player1.TotalLoses++;
            }
            else // Se Player1 (X) venceu
            {
                Player1.TotalWins++;
                Player2.TotalLoses++;
            }
        }

        // Verifica se há uma vitória nas linhas
        private bool CheckRowsForWin()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                int count = 0;
                int lastPiece = -1;

                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] == lastPiece && lastPiece != 0)
                    {
                        count++;
                        if (count == SequenceToWin) return true;
                    }
                    else
                    {
                        lastPiece = GameBoard[i, j];
                        count = 1;
                    }
                }
            }
            return false;
        }

        // Verifica se há uma vitória nas colunas
        private bool CheckColumnsForWin()
        {
            for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                int count = 0;
                int lastPiece = -1;

                for (int i = 0; i < GameBoard.GetLength(0); i++)
                {
                    if (GameBoard[i, j] == lastPiece && lastPiece != 0)
                    {
                        count++;
                        if (count == SequenceToWin) return true;
                    }
                    else
                    {
                        lastPiece = GameBoard[i, j];
                        count = 1;
                    }
                }
            }
            return false;
        }

        // Verifica se há uma vitória nas diagonais principais
        private bool CheckMajorDiagonalsForWin()
        {
            for (int i = 0; i <= GameBoard.GetLength(0) - SequenceToWin; i++)
            {
                for (int j = 0; j <= GameBoard.GetLength(1) - SequenceToWin; j++)
                {
                    if (CheckDiagonalForWin(i, j, 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Verifica se há uma vitória nas diagonais secundárias
        private bool CheckMinorDiagonalsForWin()
        {
            for (int i = 0; i <= GameBoard.GetLength(0) - SequenceToWin; i++)
            {
                for (int j = SequenceToWin - 1; j < GameBoard.GetLength(1); j++)
                {
                    if (CheckDiagonalForWin(i, j, -1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Verifica uma diagonal específica por uma sequência vencedora
        private bool CheckDiagonalForWin(int startX, int startY, int direction)
        {
            int count = 0;
            int lastPiece = -1;

            for (int i = 0; i < SequenceToWin; i++)
            {
                int x = startX + i;
                int y = startY + (i * direction);

                if (GameBoard[x, y] == lastPiece && lastPiece != 0)
                {
                    count++;
                    if (count == SequenceToWin) return true;
                }
                else
                {
                    lastPiece = GameBoard[x, y];
                    count = 1;
                }
            }

            return false;
        }

        // Verifica se o tabuleiro está cheio (condição de empate)
        private bool IsBoardFull()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] == 0)
                    {
                        return false; // Found an empty cell, so the board isn't full
                    }
                }
            }
            return true; // No empty cells found, so the board is full
        }


    }
}
