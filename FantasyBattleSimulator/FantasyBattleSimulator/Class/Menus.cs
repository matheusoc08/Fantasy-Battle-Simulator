using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Menus
    {
        public void Home()
        {
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
                    CharacterSelection();
                    break;
                case "2":
                    CharacterScreen();
                    break;
                case "3":
                    break;
                default:
                    break;
                    //throw new ArgumentOutOfRangeException();
            }
        }

        public void CharacterScreen()
        {
            //Informações dos personagens selecionáveis
            Warrior guerreiro = new Warrior("Guerreiro");
            Mage mago = new Mage("Mago");
            Barbarian barbaro = new Barbarian("Bárbaro");
            Assassin assassino = new Assassin("Assassino");

            while (true)
            {
                Console.WriteLine("Personagens disponíveis\n1- Guerreiro\n2- Mago\n3- Barbaro\n4- Assassino");
                Console.WriteLine();
                Console.Write("Selecione um dos personagens acima para ver seus status ou X para voltar: \n\n");

                DaoBase acesso = new DaoBase();

                int escolhaPersonagem = int.Parse(Console.ReadLine());

                acesso.CharacterInformation(escolhaPersonagem);

                ////OLD
                //var escolhaPersonagem = Console.ReadLine();
                //Console.Clear();

                //switch (escolhaPersonagem)
                //{
                //    case "1":
                //        Console.WriteLine(guerreiro.ToString());
                //        break;
                //    case "2":
                //        Console.WriteLine(mago.ToString());
                //        break;
                //    case "3":
                //        Console.WriteLine(barbaro.ToString());
                //        break;
                //    case "4":
                //        Console.WriteLine(assassino.ToString());
                //        break;
                //    default:
                //        Home();
                //        throw new ArgumentOutOfRangeException();
                //}

                Console.WriteLine("Pressione qualquer tecla para voltar a tela de personagens");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void CharacterSelection()
        {
            Console.WriteLine("Personagens disponíveis\n1- Guerreiro\n2- Mago\n3- Barbaro\n4- Assassino");
            Console.WriteLine();
            Console.Write("Selecione um dos personagens acima para lutar!\n\n");

            Console.Write("Desafiante: ");
            Character player1 = CharacterChoose(Console.ReadLine());

            Console.Write("Desafiado: ");
            Character player2 = CharacterChoose(Console.ReadLine());

            Console.Clear();
            Round batalha = new Round();
            batalha.BattleStart(player1, player2);
        }

        public static Character CharacterChoose(string chosenCharacter)
        {
            Character character = null;

            switch (chosenCharacter)
            {
                case "1":
                    Warrior guerreiro = new Warrior("Guerreiro");
                    character = guerreiro;
                    break;
                case "2":
                    Mage mago = new Mage("Mago");
                    character = mago;
                    break;
                case "3":
                    Barbarian barbaro = new Barbarian("Bárbaro");
                    character = barbaro;
                    break;
                case "4":
                    Assassin assassino = new Assassin("Assassino");
                    character = assassino;
                    break;
            }

            return character;
        }

    }
}
