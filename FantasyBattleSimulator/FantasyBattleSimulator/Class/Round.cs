using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Round
    {
        

        /*
        public void CalculateDamage(int challengerLastMove, int challengedLastMove)
        {
            switch (challengerLastMove)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Magic();
                    break;
                case 3:
                    Defense();
                    break;
            }
        }
        
        public void Attack()
        {
            Random dice = new Random();
            int lastHit = dice.Next(0, this.physicalAttack);
            lastHit += CriticalDamage(this.criticalRate, lastHit);

            if (lastHit == 0)
            {
                return $"{this.Name} errou o ataque...";
            }
            else
            {
                return $"{this.Name} ataca causando {lastHit} de dano";
            }
        }

        public void Magic()
        {
            Random dice = new Random();
            int lastHit = dice.Next(0, this.magicAttack);
            lastHit += CriticalDamage(this.criticalRate, lastHit);
            this.ManaPoints -= 20;

            if (lastHit == 0)
            {
                return $"{this.Name} errou o ataque...";
            }
            else
            {
                return $"{this.Name} lançou um feitiço causando {lastHit} de dano";
            }
        }

        public void Defense()
        {
            Random dice = new Random();

            if (dice.Next(0, 2) == 1)
            {
                return $"{this.Name} defendeu o ataque";
            }
            else
            {
                return $"{this.Name} não conseguiu defender o ataque";
            }
        }
        */
    }
}
