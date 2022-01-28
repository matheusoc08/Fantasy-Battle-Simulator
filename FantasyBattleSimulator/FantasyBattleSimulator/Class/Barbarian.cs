using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Barbarian : Character
    {
        public Barbarian (string name) : base(name)
        {
            this.HealthPoints += 100;
            this.PhysicalAttack += 10;
            this.PhysicalDefense += 15;
        }
    }
}
