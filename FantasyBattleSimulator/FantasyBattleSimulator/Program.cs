using FantasyBattleSimulator.Class;
using System;


namespace FantasyBattleSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus menu = new Menus();
            menu.Home();

            //DaoBase connection = new DaoBase();
            //Console.WriteLine(connection.Teste(1));
        }        
    }
}
