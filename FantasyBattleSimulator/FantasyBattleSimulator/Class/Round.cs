using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Round
    {
        public void Lutar(Character player1, Character player2)
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
            menu.MenuInicial();
        }

    }
}
