using Microsoft.Win32;
using System;
using System.ComponentModel.Design;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace Projeto_IP
{
    internal class Program
    {
        public static List<Player> Players = new List<Player>();
        public static Board  Game = new Board();
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("N em Linha");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Projeto Realizado por:\n->Carolyne Rocha - 202309\n->Isaac Macieira - 2022089\n->Jeovani Cosme - 2023016\n->Pedro Santos -2023010");
            Console.WriteLine("\n---------------------\n\n");
            CreatePlayersTester();
            StartGameTester();
            Menu();
        }

        /// <summary>
        /// Apenas para Subir o projeto ja com o Jogo criado para nao estar sempre a ser criado
        /// </summary>
        private static void StartGameTester()
        {
            Game.GameBoard = new int[5, 5];
            
            Game.Player1 = Players.ElementAt(0);
            Game.Player2 = Players.ElementAt(1);
            Game.Player1.EspecialPiecesAvaiable = 2;
            Game.Player2.EspecialPiecesAvaiable = 2;
            Game.Player1.IsInGame = true;
            Game.Player1.IsInGame = true;
            Game.SequenceToWin = 4;
            Game.SpecialPieceLenght = 2;
            Game.InGame = true;

        }

        /// <summary>
        /// Criar alguns jogadores para ja ter dados
        /// </summary>
        private static void CreatePlayersTester()
        {
            Players.Add(new Player("Pedro"));
            Players.Add(new Player("Joao"));
            Players.Add(new Player("Ricardo"));
            Players.Add(new Player("Esteves"));
            Players.Add(new Player("Rita"));
            Players.Add(new Player("Catarina"));
            Players.Add(new Player("Ana"));
            Players.Add(new Player("Jeovani"));
            Players.Add(new Player("Ines"));
        }

        /// <summary>
        /// Menu de escolha 
        /// </summary>
        public static void Menu()
        {
            string? input;
            do
            {
                Console.Write("Menu Jogo:\n");
                Console.WriteLine("" +
                    "RJ- REGISTAR JOGADOR\n" +
                    "EJ- REMOVER JOGADOR\n" +
                    "LJ- LISTAR JOGADORES\n" +
                    "IJ- INICIAR JOGO\n" +
                    "DJ- DETALHES JOGO\n" +
                    "D-  DESISTIR\n" +
                    "CP- COLOCAR PEÇA\n" +
                    "V-  VISUALIZAR JOGO\n" +
                    "S-  SAIR");

                Console.Write("Escolha uma opçao do menu -> ");
                 input = Console.ReadLine().ToUpper();
                try
                {

                switch (input)
                {
                    case "RJ":
                        Console.Clear();    
                        CreatePlayer();
                        break;
                    case "EJ":
                        Console.Clear();
                        RemovePlayer();
                        break;
                    case "LJ":
                        Console.Clear();
                        ListPlayers();
                        break;
                    case "IJ":
                        Console.Clear();
                        StartGame();
                        break;
                    case "DJ":
                        Console.Clear();
                        GameDetails();
                        break;
                    case "D":
                        Console.Clear();
                        GiveUpGame();
                        break;
                    case "CP":
                        Console.Clear();
                        MakeAMove();
                        break;
                    case "V":
                        Console.Clear();
                        CheckBoard();
                        break;
                    case "S":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Introduza uma input valida... \n\n");
                        input = "";
                        break;

                }
                }
                catch
                {
                    Console.WriteLine("Algo correu mal...");
                    Console.Write("\n\nPrima qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (input != "S");
        }

        /// <summary>
        /// Mostra o estado atual da grelha do jogo em curso, indicando o conteúdo de
        /// cada posição.As posições são mostradas de cima para baixo, da esquerda para a direita, indicando
        /// linha, coluna, e conteúdo.
        /// </summary>
        private static void CheckBoard()
        {
            if (!Game.InGame)
            {
                Console.WriteLine("Não esta a decorrer qualquer jogo...");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            DisplayBoardWithSelection(-1);
            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Um jogador coloca uma peça, se fizer parte do jogo em curso, e for a sua vez. Se
        /// nenhum jogador tiver colocado peças no jogo em curso, qualquer um pode ser o primeiro.
        /// Nome é um nome de um jogador, TamanhoPeça é o tamanho da peça a colocar, Posição é a
        /// coordenada horizontal onde a peça será colocada, e Sentido é o sentido (E ou D), na horizontal,
        /// para onde a peça será colocada.OSentido é opcional, podendo ser omitido quando a peça tem
        /// tamanho 1.
        /// </summary>
        private static void MakeAMove()
        {
            if (!Game.InGame)
            {
                Console.WriteLine("Não está a decorrer qualquer jogo...");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            ConsoleKeyInfo key;
            int selectedColumn = 0;
            bool usingSpecialPiece = false;
            char direction = 'D'; // Direção default =  direita ('D' para direita, 'E' para esquerda)
            do
            {
                Console.Clear();
                string specialPiece = usingSpecialPiece ? "Ativado" : "Desativado";
                Player currentPlayer = Game.PlayerMove ? Game.Player2 : Game.Player1;
                DisplayBoardWithSelection(selectedColumn);
                Console.WriteLine($"\nÉ a vez de {currentPlayer.Name}. Use as setas <- | -> para escolher uma coluna e pressione Enter para colocar a peça.");
                Console.WriteLine($"\nPEÇA ESPECIAL: {specialPiece} => Pressione 'P' para usar uma peça especial. ");
                if (usingSpecialPiece)
                {
                    Console.WriteLine($"\nPeças especiais disponíveis: {currentPlayer.EspecialPiecesAvaiable}.");
                    Console.WriteLine($"Pressione 'D' para a direita ou 'E' para a esquerda após selecionar a peça especial. Posicção Atual : {direction}");
                }
                Console.WriteLine("\nPressione 'Q' para sair do menu.");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        Console.Clear();
                        return; // Sai do jogo
                    case ConsoleKey.P:
                        usingSpecialPiece = !usingSpecialPiece;
                        break;
                    case ConsoleKey.D:
                        direction = 'R'; // Muda direção para direita
                        break;
                    case ConsoleKey.E:
                        direction = 'E'; // Muda direção para esquerda
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedColumn = Math.Max(0, selectedColumn - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        selectedColumn = Math.Min(Game.GameBoard.GetLength(1) - 1, selectedColumn + 1);
                        break;
                    case ConsoleKey.Enter:
                        PlacePiece(selectedColumn, currentPlayer, usingSpecialPiece, direction);
                        int gameResult = Game.CheckForWinOrDraw();
                        if (gameResult != 0)
                        {
                            DisplayBoardWithSelection(-1); // Mostra o estado final da Board
                            if (gameResult == 1) // Vitória
                            {
                                string winnerName = Game.PlayerMove ? Game.Player2.Name : Game.Player1.Name;
                                Console.WriteLine($"\n{winnerName} venceu! Pressione qualquer tecla para retornar ao menu.");
                            }
                            else if (gameResult == 2) // Empate
                            {
                                Console.WriteLine("\nEmpate! Pressione qualquer tecla para retornar ao menu.");
                            }

                            Console.ReadKey();
                            Console.Clear();

                            Game.InGame = false;
                            return; // Termina o jogo
                        }
                        usingSpecialPiece = false;
                        Game.PlayerMove = !Game.PlayerMove;
                        break;
                }
            } while (true); // Continua até 'Q' ser pressionado ou o jogo termine
        }

        private static void PlacePiece(int column, Player player, bool usingSpecialPiece, char direction)
        {
            if (usingSpecialPiece)
            {
                for (int i = 0; i < Game.SpecialPieceLenght; i++)
                {
                    int targetColumn = direction == 'D' ? (column + i) % Game.GameBoard.GetLength(1) : (column - i + Game.GameBoard.GetLength(1)) % Game.GameBoard.GetLength(1);
                    DropPieceInColumn(targetColumn, player);
                }
                player.EspecialPiecesAvaiable--;
            }
            else
            {
                DropPieceInColumn(column, player);
            }
        }

        private static void DropPieceInColumn(int column, Player player)
        {
            for (int i = Game.GameBoard.GetLength(0) - 1; i >= 0; i--)
            {
                if (Game.GameBoard[i, column] == 0)
                {
                    Game.GameBoard[i, column] = Game.PlayerMove ? 2 : 1;
                    break;
                }
            }
        }

        private static void DisplayBoardWithSelection(int selectedColumn)
        {
            int columns = Game.GameBoard.GetLength(1);

            Console.WriteLine($"Player 1: {Game.Player1.Name} (X)  -  Player 2: {Game.Player2.Name} (O)\n");
            Console.Write("  ");
            for (int j = 0; j < columns; j++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            for (int i = 0; i < Game.GameBoard.GetLength(0); i++)
            {
                Console.Write("  |");
                for (int j = 0; j < columns; j++)
                {
                    char piece = Game.GameBoard[i, j] switch
                    {
                        1 => 'X',
                        2 => '0',
                        _ => ' '
                    };
                    Console.Write($" {piece} |");
                }
                Console.WriteLine();
                Console.Write("  ");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
            }

            Console.Write("   ");
            for (int j = 1; j <= columns; j++)
            {
                Console.Write($" {j}  ");
            }
            Console.WriteLine();
            if(selectedColumn != -1)
            Console.WriteLine($"{' '.ToString().PadLeft(3 * selectedColumn + 3)}Column {selectedColumn + 1}");
        }



        /// <summary>
        /// Um jogador pode desistir do jogo em curso do qual faz parte, pelo que o outro jogador
        /// regista uma vitória.Ambos registam mais um jogo jogado.Caso os dois jogadores desistam, ambos
        /// somam um jogo jogado, sem vitória atribuída.
        /// </summary>
        private static void GiveUpGame()
        {
            Console.WriteLine("Desistir do Jogo");
            Console.WriteLine("-------------------------\n");

            if(!Game.InGame)
            {
                Console.WriteLine("Não esta a decorrer qualquer jogo...");
               
                return;
            }

            Console.Write("Quem deseja desistir:\n");
            Console.WriteLine("" +
                $"1- {Game.Player1.Name}\n" +
                $"2- {Game.Player2.Name}\n" +
                $"3- Ambos\n" +
                "S-  Cancelar");

            Console.Write("Escolha uma opçao do menu -> ");
            string? input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "1":
                    Game.Player1.TotalLoses++;
                    Game.Player2.TotalWins++;
                    Game.Player1.IsInGame = false;
                    Game.Player2.IsInGame = false;
                    Game.InGame = false;
                    Console.WriteLine($"{Game.Player2.Name} Ganhou!!");
                    break;
                case "2":
                    Game.Player1.TotalLoses++;
                    Game.Player2.TotalWins++;
                    Game.Player1.IsInGame = false;
                    Game.Player2.IsInGame = false;
                    Game.InGame = false;

                    Console.WriteLine($"{Game.Player1.Name} Ganhou!!");
                    break;
                        
                case "3":
                    Game.Player1.TotalDraws++;
                    Game.Player2.TotalDraws++;
                    Game.Player1.IsInGame = false;
                    Game.Player2.IsInGame = false;
                    Game.InGame = false;

                    Console.WriteLine($"Empate entre {Game.Player1.Name} e {Game.Player2.Name} por desistência mútua");
                    break;
                case "S":
                    Console.WriteLine("Cancelado...");
                    break;
                default:
                    Console.WriteLine("Resposta Invalida... \n\n");
                    break;
            }

            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Mostra informação sobre o jogo em curso: tamanho da grelha, jogadores por
        /// ordem alfabética, e tipo e quantidade de peças especiais disponíveis para cada jogador.
        /// Comprimento e Altura são as dimensões da grelha de jogo, Nome é um nome de um jogador,
        /// TamanhoPeça é o tamanho de uma peça especial, e Quantidade é o número de peças especiais
        /// atualmente disponíveis para o jogador.
        /// </summary>
        private static void GameDetails()
        {
            Console.WriteLine("Detalhes de Jogo");
            Console.WriteLine("-------------------------\n");

            if (! Game.InGame)
            {
                Console.WriteLine("Não existe jogo em curso..\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine($"Tamanho da Grelha: { Game.GameBoard.GetLength(0)} x { Game.GameBoard.GetLength(1)} \n");

            // Ordenar os jogadores alfabeticamente
            Player player1 =  Game.Player1;
            Player player2 =  Game.Player2;
            if (string.Compare(player1.Name, player2.Name, StringComparison.OrdinalIgnoreCase) > 0)
            {
                // Se player2 vem antes alfabeticamente, trocar a ordem
                player1 =  Game.Player2;
                player2 =  Game.Player1;
            }
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Nome Jogador", "Tamanho da Peça", "Quantidade:");
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", player1.Name,  Game.SpecialPieceLenght, player1.EspecialPiecesAvaiable);
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", player2.Name,  Game.SpecialPieceLenght, player2.EspecialPiecesAvaiable);


            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }


        /// <summary>
        /// Inicia um novo jogo, se não estiver ainda um jogo iniciado. É necessário indicar o
        ///nome dos jogadores que irão participar, as dimensões da grelha, o tamanho da sequência vencedora,
        ///e as peças especiais disponíveis.Os jogadores têm que estar previamente registados.O jogo inicia
        ///indicando o nome dos jogadores que nele participam por ordem alfabética.
        ///Nome é um nome de um jogador, Comprimento e Altura são as dimensões da grelha de jogo,
        ///TamanhoSequência é o tamanho da sequência vencedora, e TamanhoPeça é o tamanho de uma
        ///peça especial.
        ///Nenhum valor de TamanhoPeça pode ser igual ou superior a TamanhoSequência vencedora.
        /// </summary>
        private static void StartGame()
        {
            Console.WriteLine("Iniciar Jogo");
            Console.WriteLine("-------------------------\n");
            if( Game.InGame)
            {
                Console.WriteLine("Existe um jogo em curso.\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Write("Nome jogador 1 -> ");
            string? player1 = Console.ReadLine();
            Console.Write("Nome jogador 2 -> ");
            string? player2 = Console.ReadLine();

             Game.Player1 = Players.Find(jogador => jogador.Name.Equals(player1));
             Game.Player2 = Players.Find(jogador => jogador.Name.Equals(player2));

            if( Game.Player1 == null ||  Game.Player2 == null)
            {
                Console.WriteLine("Jogador não registado.\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Write("Comprimento da grelha -> ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Largura da grelha -> ");
            int columns = int.Parse(Console.ReadLine());
            Game.GameBoard = new int[lines,columns];
            do
            {
                Console.Write("Tamanho da sequência vencedora -> ");
                Game.SequenceToWin = int.Parse(Console.ReadLine());
                if (Game.SequenceToWin > lines || Game.SequenceToWin > columns)
                {
                    Console.WriteLine("O tamanho da sequência vencedora não pode ser maior que a grelha de jogo");
                    Game.SequenceToWin = 0;
                }
                else break;
            } while (true);

            do
            {
                Console.Write("Tamanho da peça especial -> ");
                Game.SpecialPieceLenght = int.Parse(Console.ReadLine());
                if (Game.SpecialPieceLenght >= Game.SequenceToWin)
                {
                    Console.WriteLine("Peça especial tem que ser mais pequena que a sequencia de jogo!!");
                    Game.SpecialPieceLenght = 0;
                }
                else break;
            } while (true);

            Console.Write("Quantas peças especiais por jogador -> ");
            int piecesAvaiable = int.Parse(Console.ReadLine());
             Game.Player1.EspecialPiecesAvaiable = piecesAvaiable;
             Game.Player2.EspecialPiecesAvaiable = piecesAvaiable;
             Game.InGame = true;
            Console.WriteLine($"Jogo iniciado entre { Game.Player1.Name} e { Game.Player2.Name}\n");
            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Lista todos jogadores registados, indicando o número de jogos jogados e vitórias.
        ///Nome é um nome de um jogador, Jogos é o número de jogos jogados pelo jogador, e Vitórias
        ///é o seu número de vitórias.
        /// </summary>
        private static void ListPlayers()
        {
            Console.WriteLine("Listar Jogadores");
            Console.WriteLine("-------------------------\n");
            if (Players.Count == 0)
            {
                Console.WriteLine("Não existem jogadores registados.\n");
            }
            else
            {
                Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15} {4,-15}",
                    "Nome Jogador", "Total Vitórias", "Total Empates", "Total Derrotas", "Total Jogos");

                foreach (Player jogador in Players)
                {
                    Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15} {4,-15}",
                        jogador.Name, jogador.TotalWins, jogador.TotalDraws, jogador.TotalLoses,
                        jogador.TotalGames());
                }
            }

            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Remove um jogador previamente registado, se este não estiver a participar no
        ///jogo em curso.
        /// </summary>
        private static void RemovePlayer()
        {
            Console.WriteLine("Remover Jogador");
            Console.WriteLine("-------------------\n");
            Console.Write("Insira o nome do jogador ->");
            string name = Console.ReadLine();
            Player? checkPlayer = Players.Find(jogador => jogador.Name.Equals(name));

            if (checkPlayer != null)
            {
                Console.WriteLine("Jogador não existente.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            else if (checkPlayer.IsInGame)
            {
                Console.WriteLine("Jogador participa no jogo em curso.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            else
            {
                Players.Remove(checkPlayer);
                Console.WriteLine("Jogador removido com sucesso...");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Regista um novo jogador. Cada jogador tem um nome único. Não existe limite
        /// para o número de jogadores registados.
        /// </summary>
        private static void CreatePlayer()
        {
            Console.WriteLine("Registo novo Jogador");
            Console.WriteLine("-------------------\n");
            Console.Write("Insira o nome do jogador ->");
            string nome = Console.ReadLine();
            Player newPlayer = new Player(nome);
            Player checkPlayer = Players.Find(jogador => jogador.Name.Equals(newPlayer.Name));
            if (checkPlayer != null)
            {
                Console.WriteLine("Jogador existente.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Players.Add(newPlayer);
                Console.WriteLine("Jogador registado com sucesso.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}