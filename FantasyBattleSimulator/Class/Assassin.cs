using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    class Assassin : Character
    {
        public Assassin (string name) : base(name)
        {
            this.PhysicalAttack += 20;
            this.CriticalRate += 30;
        }
    }
}
