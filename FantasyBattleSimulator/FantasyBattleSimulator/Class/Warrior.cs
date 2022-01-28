using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    public class Warrior : Character
    {
        public Warrior (string name) : base(name)
        {
            this.HealthPoints += 50;
            this.PhysicalAttack += 15;
            this.PhysicalDefense += 10;
            this.CriticalRate += 4;
        }
    }
}
