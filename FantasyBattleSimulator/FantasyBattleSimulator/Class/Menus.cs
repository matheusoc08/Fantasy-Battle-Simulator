using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Menus
    {
        readonly DaoBase acessoBase = new DaoBase();

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
            while (true)
            {

                Console.WriteLine(acessoBase.CharacterInformation());
                Console.WriteLine();
                Console.Write("Selecione um dos personagens acima para ver seus status ou X para voltar: ");

                var escolhaPersonagem = Console.ReadLine();

                if (escolhaPersonagem == "")
                {
                    Console.Clear();
                    Home();
                    break;
                }
                else
                {
                    var personagem = acessoBase.CharacterInformation(int.Parse(escolhaPersonagem));
                    Console.WriteLine(personagem);

                    Console.WriteLine("Pressione qualquer tecla para voltar a tela de personagens");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void CharacterSelection()
        {
            Console.WriteLine(acessoBase.CharacterInformation());
            Console.WriteLine();
            Console.Write("Selecione um dos personagens acima para lutar!\n\n");

            Console.Write("Desafiante: ");
            Character player1 = acessoBase.CharacterInformation(int.Parse(Console.ReadLine()));

            Console.Write("Desafiado: ");
            Character player2 = acessoBase.CharacterInformation(int.Parse(Console.ReadLine()));

            Console.Clear();
            Round batalha = new Round();
            batalha.BattleStart(player1, player2);
        }

    }
}
