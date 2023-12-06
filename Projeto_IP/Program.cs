using System.ComponentModel.Design;

namespace Projeto_IP
{
    internal class Program
    {
        public static List<Player> Players = new List<Player>();
        public static Board Board = new Board();
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Inline N");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Project done by :\n->Carolyne Rocha - 202309\n->Isaac Macieira - 2022089\n->Jeovani Cosme - 2023016\n->Pedro Santos -2023010");
            Console.WriteLine("\n---------------------\n\n");
            //CreatePlayer();
            Menu();
        }

        private static void CreatePlayer()
        {
            Players.Add(new Player("Pedro", 2231,51));
            Players.Add(new Player("Joao", 21,5));
            Players.Add(new Player("Ricardo", 221,51));
            Players.Add(new Player("Esteves", 231,51));
            Players.Add(new Player("Rita", 2,5));
            Players.Add(new Player("Catarina", 2231,51));
            Players.Add(new Player("Ana", 211,51));
            Players.Add(new Player("Jeovani", 2231,51));
            Players.Add(new Player("Ines", 2231,51));
        }

        public static void Menu()
        {
            string userInput;
            do
            {
                Console.Write("Game Menu:\n");
                Console.WriteLine("" +
                    "RJ- ADD PLAYER\n" +
                    "EJ- REMOVE PLAYER\n" +
                    "LJ- LIST PLAYERS\n" +
                    "IJ- PLAY GAME\n" +
                    "DJ- GAME STATS\n" +
                    "D-  GIVE UP\n" +
                    "CP- MAKE A MOVE\n" +
                    "V-  DISPLAY GAME\n" +
                    "S-  QUIT");

                Console.Write("Select a menu option -> ");
                 userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "RJ":
                        Console.Clear();    
                        AddPlayer();
                        break;
                    case "EJ":
                        Console.Clear();
                        RemovePlayer();
                        break;
                    case "LJ":
                        Console.Clear();
                        ListPlayer();
                        break;
                    case "IJ":
                        Console.Clear();
                        PlayGame();
                        break;
                    case "DJ":
                        Console.Clear();
                        GameStats();
                        break;
                    case "D":
                        Console.Clear();
                        GiveUp();
                        break;
                    case "CP":
                        Console.Clear();
                        MakeAMove();
                        break;
                    case "V":
                        Console.Clear();
                        DisplayGame();
                        break;
                    case "S":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please,check your answer... \n\n");
                        userInput = "";
                        break;

                }

            }while (userInput != "S");
        }

        private static void DisplayGame()
        {
            throw new NotImplementedException();
        }

        private static void MakeAMove()
        {
            throw new NotImplementedException();
        }

        private static void GiveUp()
        {
            throw new NotImplementedException();
        }

        private static void GameStats()
        {
            throw new NotImplementedException();
        }

        private static void PlayGame()
        {
            throw new NotImplementedException();
        }

        private static void ListPlayer()
        {
            Console.WriteLine("Players List");
            foreach (Player player in Players)
            {
                Console.WriteLine($"\n{player.Name,15}");
            }
        }

        private static void RemovePlayer()
        {
            Console.WriteLine("Remove Player");
            Console.WriteLine("Which player do you want to remove?");
            string playerToRemove = Console.ReadLine();
            Player listPlayerToRemove = Players.Find(x => x.Name.Contains(playerToRemove));
            if (listPlayerToRemove != null)
            {
                Players.Remove(listPlayerToRemove);
                Console.WriteLine("The player was removed!");
                Console.WriteLine("");
            }
        }

        private static void AddPlayer()
        {
            Console.WriteLine("Create Player");
            Console.WriteLine("What´s the player name ?:");
            Player novoJogador = new Player(Console.ReadLine(),0,0);
            Players.Add(novoJogador);
            Console.WriteLine("Player added successfully!");
            Console.WriteLine("");
        }
    }
}