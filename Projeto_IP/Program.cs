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
            Console.WriteLine("Detalhes de Jogo");
            Console.WriteLine("-------------------------\n");

            if (!Tabuleiro.JogoEmCurso)
            {
                Console.WriteLine("Não existe jogo em curso..\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("Detalhes do Jogo:");
            Console.WriteLine($"Tamanho da Grelha: {Tabuleiro.Jogo.GetLength(0)} x {Tabuleiro.Jogo.GetLength(1)} \n");

            // Ordenar os jogadores alfabeticamente
            Jogador jogador1 = Tabuleiro.Jogador1;
            Jogador jogador2 = Tabuleiro.Jogador2;
            if (string.Compare(jogador1.Nome, jogador2.Nome, StringComparison.OrdinalIgnoreCase) > 0)
            {
                // Se jogador2 vem antes alfabeticamente, trocar a ordem
                jogador1 = Tabuleiro.Jogador2;
                jogador2 = Tabuleiro.Jogador1;
            }
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Nome Jogador", "Tamanho da Peça", "Quantidade:");
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", jogador1.Nome, Tabuleiro.TamanhoPecaEspecial, jogador1.PecasEspeciaisDisponveis);
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", jogador2.Nome, Tabuleiro.TamanhoPecaEspecial, jogador2.PecasEspeciaisDisponveis);


            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }


        private static void IniciarJogo()
        {
            Console.WriteLine("Iniciar Jogo");
            Console.WriteLine("-------------------------\n");
            if(Tabuleiro.JogoEmCurso)
            {
                Console.WriteLine("Existe um jogo em curso.\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Write("Nome jogador 1 -> ");
            string jogador1 = Console.ReadLine();
            Console.Write("Nome jogador 2 -> ");
            string jogador2 = Console.ReadLine();

            Tabuleiro.Jogador1 = Jogadores.Find(jogador => jogador.Nome.Equals(jogador1));
            Tabuleiro.Jogador2 = Jogadores.Find(jogador => jogador.Nome.Equals(jogador2));

            if(Tabuleiro.Jogador1 == null || Tabuleiro.Jogador2 == null)
            {
                Console.WriteLine("Jogador não registado.\n");
                Console.Write("\n\nPrima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Write("Comprimento da grelha -> ");
            int linhas = int.Parse(Console.ReadLine());
            Console.Write("Largura da grelha -> ");
            int colunas = int.Parse(Console.ReadLine());
            Tabuleiro.Jogo = new int[linhas,colunas];
            Console.Write("Tamanho da sequência vencedora -> ");
            Tabuleiro.SequenciaParaGanhar = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Tamanho da peça especial -> ");
                Tabuleiro.TamanhoPecaEspecial = int.Parse(Console.ReadLine());
                if(Tabuleiro.TamanhoPecaEspecial >= Tabuleiro.SequenciaParaGanhar)
                {
                    Console.WriteLine("Peça especial tem que ser mais pequena que a sequencia de jogo!!");
                    Tabuleiro.TamanhoPecaEspecial = 0;
                }
                else
                {
                    break;
                }
                
            } while (true);
            Console.Write("Quantas peças especiais por jogador -> ");
            int pecasDisponives = int.Parse(Console.ReadLine());
            Tabuleiro.Jogador1.PecasEspeciaisDisponveis = pecasDisponives;
            Tabuleiro.Jogador2.PecasEspeciaisDisponveis = pecasDisponives;
            Tabuleiro.JogoEmCurso = true;
            Console.WriteLine($"Jogo iniciado entre {Tabuleiro.Jogador1.Nome} e {Tabuleiro.Jogador2.Nome}\n");
            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ListarJogadores()
        {
            Console.WriteLine("Listar Jogadores");
            Console.WriteLine("-------------------------\n");
            if (Jogadores.Count == 0)
            {
                Console.WriteLine("Não existem jogadores registados.\n");
            }
            else
            {
                Console.WriteLine("{0,-20} {1,-12} {2,-15}", "Nome Jogador", "Total Jogos", "Total Vitorias");

                foreach (Jogador jogador in Jogadores)
                {
                    Console.WriteLine("{0,-20} {1,-12} {2,-15}", jogador.Nome, jogador.TotalJogos, jogador.TotalVitorias);
                }
            }

            Console.Write("\n\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void RemoverJogador()
        {
            Console.WriteLine("Remover Jogador");
            Console.WriteLine("-------------------\n");
            Console.Write("Insira o nome do jogador ->");
            string nome = Console.ReadLine();
            Jogador? verificarJogador = Jogadores.Find(jogador => jogador.Nome.Equals(nome));

            if (verificarJogador != null)
            {
                Console.WriteLine("Jogador não existente.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            else if (verificarJogador.EstaEmJogo)
            {
                Console.WriteLine("Jogador participa no jogo em curso.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            else
            {
                Jogadores.Remove(verificarJogador);
                Console.WriteLine("Jogador removido com sucesso...");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void RegistarJogador()
        {
            Console.WriteLine("Registo novo Jogador");
            Console.WriteLine("-------------------\n");
            Console.Write("Insira o nome do jogador ->");
            string nome = Console.ReadLine();
            Jogador novoJogador = new Jogador(nome);
            Jogador verificarJogador = Jogadores.Find(jogador => jogador.Nome.Equals(novoJogador.Nome));
            if (verificarJogador != null)
            {
                Console.WriteLine("Jogador existente.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Jogadores.Add(novoJogador);
                Console.WriteLine("Jogador registado com sucesso.");
                Console.Write("Prima qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}