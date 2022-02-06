using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class CharacterAction
    {

        public void PhysicalAttack(Character attacker, Character attacked)
        {
            //DaoBase acessoBase = new DaoBase();
            //acessoBase.ChosenMove(chosenMove);

            
            Random dice = new Random();
            attacker.LastHit = dice.Next(0, attacker.PhysicalAttack);
            attacker.LastHit += CriticalDamage(attacker.CriticalRate, attacker.LastHit);

            Console.WriteLine($"{attacker.Name} avançou para o ataque.");

            int damage = attacker.LastHit - attacked.PhysicalDefense;

            if ((damage) <= 0)
            {
                Console.WriteLine($"{attacked.Name} defendeu o ataque!");
            }
            else
            {
                Console.WriteLine($"{attacked.Name} recebeu {damage} de dano físico");
                attacked.HealthPoints -= damage;
            }
            
        }

        public void MagicAttack(Character attacker, Character attacked)
        {
            
            if (attacker.ManaPoints < 20)
            {
                Console.WriteLine($"{attacker.Name} não possui mana suficiente para lançar uma magia!");
                attacker.LastHit = -1;
                return;
            }
            else
            {
                Random dice = new Random();
                attacker.LastHit = dice.Next(0, attacker.MagicAttack);
                attacker.LastHit += CriticalDamage(attacker.CriticalRate, attacker.LastHit);
                attacker.ManaPoints -= 20;

                Console.WriteLine($"{attacker.Name} lançou um ataque mágico.");
            }

            int damage = attacker.LastHit - attacked.MagicDefense;

            if (damage <= 0)
            {
                Console.WriteLine($"{attacked.Name} defendeu o ataque!");
            }
            else
            {
                Console.WriteLine($"{attacked.Name} recebeu {damage} de dano mágico");
                attacked.HealthPoints -= damage;
            }
        }

        public int CriticalDamage(int criticalRate, int lastHit)
        {
            Random dice = new Random();
            double amplifier = 0.5;
            double criticalDamage = 0;

            if (dice.Next(0, 100) <= criticalRate)
            {
                criticalDamage = lastHit * amplifier;
                Console.WriteLine($"Ataque fortalecido! (Crítico)");
            }
            return Convert.ToInt32(criticalDamage);
        }

    }
}
