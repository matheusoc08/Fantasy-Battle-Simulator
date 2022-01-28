using FantasyBattleSimulator.Class;
using System;


namespace FantasyBattleSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuInicial();

        }

        public static void MenuInicial()
        {
            Warrior guerreiro = new Warrior("Guerreiro");
            Mage mago = new Mage("Mago");
            Barbarian barbaro = new Barbarian("Bárbaro");
            Assassin assassino = new Assassin("Assassino");

            //Menu inicial
            Console.WriteLine("Seleciona uma opção:");
            Console.WriteLine("1- Lutar");
            Console.WriteLine("2- Personagens");
            Console.WriteLine("3- Sair");

            var opcaoJogador = Console.ReadLine();
            Console.Clear();

            switch (opcaoJogador)
            {
                case "1":
                    SelecaoPersonagem();
                    break;
                case "2":
                    TelaPersonagens();
                    break;
                case "3":
                    break;
                default:
                    break;
                    //throw new ArgumentOutOfRangeException();
            }
        }

        public static void SelecaoPersonagem()
        {

            Warrior guerreiro = new Warrior("Guerreiro");
            Mage mago = new Mage("Mago");
            Barbarian barbaro = new Barbarian("Bárbaro");
            Assassin assassino = new Assassin("Assassino");

            Console.WriteLine("Personagens disponíveis\n1- Guerreiro\n2- Mago\n3- Barbaro\n4- Assassino");
            Console.WriteLine();
            Console.Write("Selecione um dos personagens acima para lutar!\n\n");

            Character player1 = null;
            Character player2 = null;

            Console.Write("Desafiante: ");
            var escolhaPersonagem1 = Console.ReadLine();
            switch (escolhaPersonagem1)
            {
                case "1":
                    //Warrior guerreiro = new Warrior("Guerreiro");
                    player1 = guerreiro;
                    break;
                case "2":
                    //Mage mago = new Mage("Mago");
                    player1 = mago;
                    break;
                case "3":
                    //Barbarian barbaro = new Barbarian("Bárbaro");
                    player1 = barbaro;
                    break;
                case "4":
                    //Assassin assassino = new Assassin("Assassino");
                    player1 = assassino;
                    break;
            }

            Console.Write("Desafiado: ");
            var escolhaPersonagem2 = Console.ReadLine();
            switch (escolhaPersonagem2)
            {
                case "1":
                    //Warrior guerreiro = new Warrior("Guerreiro");
                    player2 = guerreiro;
                    break;
                case "2":
                    //Mage mago = new Mage("Mago");
                    player2 = mago;
                    break;
                case "3":
                    //Barbarian barbaro = new Barbarian("Bárbaro");
                    player2 = barbaro;
                    break;
                case "4":
                    //Assassin assassino = new Assassin("Assassino");
                    player2 = assassino;
                    break;
            }

            Console.Clear();
            Lutar(player1, player2);
        }

        public static void TelaPersonagens()
        {
            //Personagens selcionáveis
            Warrior guerreiro = new Warrior("Guerreiro");
            Mage mago = new Mage("Mago");
            Barbarian barbaro = new Barbarian("Bárbaro");
            Assassin assassino = new Assassin("Assassino");

            while (true)
            {
                Console.WriteLine("Personagens disponíveis\n1- Guerreiro\n2- Mago\n3- Barbaro\n4- Assassino");
                Console.WriteLine();
                Console.Write("Seleciona um dos personagens acima para ver seus status ou X para voltar: ");

                var escolhaPersonagem = Console.ReadLine();
                Console.Clear();

                switch (escolhaPersonagem)
                {
                    case "1":
                        Console.WriteLine(guerreiro.ToString());
                        break;
                    case "2":
                        Console.WriteLine(mago.ToString());
                        break;
                    case "3":
                        Console.WriteLine(barbaro.ToString());
                        break;
                    case "4":
                        Console.WriteLine(assassino.ToString());
                        break;
                    default:
                        MenuInicial();
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine("Pressione qualquer tecla para voltar a tela de personagens");
                Console.ReadLine();
                Console.Clear();

            }
        }

        public static void Lutar(Character player1, Character player2)
        {

            Console.WriteLine(player1);
            Console.WriteLine(player2);

            int roundCount = 0;

            Console.WriteLine("=====Início da batalha!=====");
            while (true)
            {
                Console.WriteLine("Pressione qualquer tecla para avançar o round");
                Console.ReadLine();
                Console.Clear();
                roundCount++;
                if (player1.HealthPoints <= 0)
                {
                    Console.WriteLine("=====Fim da batalha!=====");
                    Console.WriteLine($"Nome: {player1.Name}\nHP: {0}\n");
                    Console.WriteLine($"Nome: {player2.Name}\nHP: {player2.HealthPoints}\n");
                    Console.WriteLine($"{player2.Name} venceu!");
                    break;
                }
                else if (player2.HealthPoints <= 0)
                {
                    Console.WriteLine("=====Fim da batalha!=====");
                    Console.WriteLine($"Nome: {player1.Name}\nHP: {player1.HealthPoints}\n");
                    Console.WriteLine($"Nome: {player2.Name}\nHP: {0}\n");
                    Console.WriteLine($"{player1.Name} venceu!");
                    break;
                }
                else
                {
                    Console.WriteLine($"=============Turno {roundCount}==============");
                    Console.WriteLine("---------STATUS PERSONAGEM---------");
                    Console.WriteLine($"Nome: {player1.Name}\nHP: {player1.HealthPoints}\nMP: {player1.ManaPoints}\n");
                    Console.WriteLine($"Nome: {player2.Name}\nHP: {player2.HealthPoints}\nMP: {player2.ManaPoints}\n");

                    Console.WriteLine("-----------LOG DE ATAQUE-----------");

                    Random dice = new Random();
                    //P1 Ataque
                    if (dice.Next(0, 2) == 1)
                    {
                        Console.WriteLine(player1.Attack());
                        player2.TakePAtk(player1.LastHit);
                    }
                    else
                    {
                        Console.WriteLine(player1.Magic());
                        player2.TakeMAtk(player1.LastHit);
                    }

                    //P2 Ataque
                    if (dice.Next(0, 2) == 1)
                    {
                        Console.WriteLine(player2.Attack());
                        player1.TakePAtk(player2.LastHit);
                    }
                    else
                    {
                        Console.WriteLine(player2.Magic());
                        player1.TakeMAtk(player2.LastHit);
                    }

                    Console.WriteLine();

                    Console.WriteLine("===========Fim do round============\n");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
            MenuInicial();
        }
    }
}
