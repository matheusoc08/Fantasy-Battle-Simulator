using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Menus
    {
        public void MenuInicial()
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

        public void SelecaoPersonagem()
        {
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
                    Warrior guerreiro = new Warrior("Guerreiro");
                    player1 = guerreiro;
                    break;
                case "2":
                    Mage mago = new Mage("Mago");
                    player1 = mago;
                    break;
                case "3":
                    Barbarian barbaro = new Barbarian("Bárbaro");
                    player1 = barbaro;
                    break;
                case "4":
                    Assassin assassino = new Assassin("Assassino");
                    player1 = assassino;
                    break;
            }

            Console.Write("Desafiado: ");
            var escolhaPersonagem2 = Console.ReadLine();
            switch (escolhaPersonagem2)
            {
                case "1":
                    Warrior guerreiro = new Warrior("Guerreiro");
                    player2 = guerreiro;
                    break;
                case "2":
                    Mage mago = new Mage("Mago");
                    player2 = mago;
                    break;
                case "3":
                    Barbarian barbaro = new Barbarian("Bárbaro");
                    player2 = barbaro;
                    break;
                case "4":
                    Assassin assassino = new Assassin("Assassino");
                    player2 = assassino;
                    break;
            }
            Console.Clear();
            Round batalha = new Round();
            batalha.Lutar(player1, player2);
        }

        public void TelaPersonagens()
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
                Console.Write("Selecione um dos personagens acima para ver seus status ou X para voltar: ");

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

    }
}
