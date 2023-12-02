using System.ComponentModel.Design;

namespace Projeto_IP
{
    internal class Program
    {
        public static List<Jogador> Jogadores = new List<Jogador>();
        public static Tabuleiro Tabuleiro = new Tabuleiro();
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("N em Linha");
            Console.WriteLine("---------------------\n");
            Console.WriteLine("Projeto Realizado por:\n->Carolyne Rocha - 202309\n->Isaac Macieira - 2022089\n->Jeovani Cosme - 2023016\n->Pedro Santos -2023010");
            Console.WriteLine("\n---------------------\n\n");
            CriarJogadores();
            Menu();
        }

        private static void CriarJogadores()
        {
            Jogadores.Add(new Jogador("Pedro", 2231,51));
            Jogadores.Add(new Jogador("Joao", 21,5));
            Jogadores.Add(new Jogador("Ricardo", 221,51));
            Jogadores.Add(new Jogador("Esteves", 231,51));
            Jogadores.Add(new Jogador("Rita", 2,5));
            Jogadores.Add(new Jogador("Catarina", 2231,51));
            Jogadores.Add(new Jogador("Ana", 211,51));
            Jogadores.Add(new Jogador("Jeovani", 2231,51));
            Jogadores.Add(new Jogador("Ines", 2231,51));
        }

        public static void Menu()
        {
            string resposta;
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
                 resposta = Console.ReadLine().ToUpper();
                switch (resposta)
                {
                    case "RJ":
                        Console.Clear();    
                        RegistarJogador();
                        break;
                    case "EJ":
                        Console.Clear();
                        RemoverJogador();
                        break;
                        Console.Clear();
                    case "LJ":
                        Console.Clear();
                        ListarJogadores();
                        break;
                    case "IJ":
                        Console.Clear();
                        IniciarJogo();
                        break;
                    case "DJ":
                        Console.Clear();
                        DetalhesJogo();
                        break;
                    case "D":
                        Console.Clear();
                        DesistirJogo();
                        break;
                    case "CP":
                        Console.Clear();
                        EfetuarJogada();
                        break;
                    case "V":
                        Console.Clear();
                        VisualizarResultado();
                        break;
                    case "S":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Introduza uma resposta valida... \n\n");
                        resposta = "";
                        break;

                }

            }while (resposta != "S");
        }

        private static void VisualizarResultado()
        {
            throw new NotImplementedException();
        }

        private static void EfetuarJogada()
        {
            throw new NotImplementedException();
        }

        private static void DesistirJogo()
        {
            throw new NotImplementedException();
        }

        private static void DetalhesJogo()
        {
            throw new NotImplementedException();
        }

        private static void IniciarJogo()
        {
            throw new NotImplementedException();
        }

        private static void ListarJogadores()
        {
            Console.WriteLine("Lista de Jogadores");
            foreach (Jogador jogador in Jogadores)
            {
                Console.WriteLine($"\n{jogador.Nome} | {jogador.TotalJogos} | {jogador.TotalVitorias}");
            }
            Console.WriteLine("");
        }

        private static void RemoverJogador()
        {
            Console.WriteLine("Remover Jogador");
            Console.WriteLine("Qual o jogador que deseja remover ?");
            string jogadorARemover = Console.ReadLine();
            Jogador jogadorDaListaARemover = Jogadores.Find(x => x.Nome.Contains(jogadorARemover));
            if (jogadorDaListaARemover != null)
            {
                Jogadores.Remove(jogadorDaListaARemover);
                Console.WriteLine("O jogador foi removido com sucesso!");
                Console.WriteLine("");
            }
        }

        private static void RegistarJogador()
        {
            Console.WriteLine("Registar Jogador");
            Console.WriteLine("Insira o nome do jogador a adicionar:");
            Jogador novoJogador = new Jogador(Console.ReadLine(),0,0);
            Jogadores.Add(novoJogador);
            Console.WriteLine("O jogador foi adicionado com sucesso!");
            Console.WriteLine("");
        }
    }
}