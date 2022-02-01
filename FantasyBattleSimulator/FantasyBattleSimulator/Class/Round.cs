using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Round
    {
        public void BattleStart(Character player1, Character player2)
        {
            Menus menu = new Menus();

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
                    Console.WriteLine("1- Ataque  2- Magia  Enter- Random\n");

                    ChosenMove(player1, player2);
                    
                    Console.WriteLine();
                    ChosenMove(player2, player1);

                    Console.WriteLine();

                    Console.WriteLine("===========Fim do round============\n");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
            menu.Home();
        }

        public static void ChosenMove(Character Attacker, Character Attacked)
        {
            Console.Write($"Escolha o próximo movimento do {Attacker.Name}: ");
            var moveOption = Console.ReadLine();
            
            switch (moveOption)
            {
                case "1":
                    Attacked.TakePAtk(Attacker.Attack());
                    break;
                case "2":
                    Attacked.TakeMAtk(Attacker.Magic());
                    break;
                default:
                    RandomMove(Attacker, Attacked);
                    break;
            }
        }

        public static void RandomMove(Character Attacker, Character Attacked)
        {
            Random dice = new Random();

            if(dice.Next(0,2) == 1)
            {
                Attacked.TakePAtk(Attacker.Attack());
            }
            else
            {
                Attacked.TakeMAtk(Attacker.Magic());
            }
        }

    }
}
