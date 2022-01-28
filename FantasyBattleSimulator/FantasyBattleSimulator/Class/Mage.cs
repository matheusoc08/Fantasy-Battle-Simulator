using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    public class Mage : Character
    {
        public Mage (string name) : base(name)
        {
            this.ManaPoints += 100;
            this.MagicAttack += 30;
            this.MagicDefense += 10;
        }
    }
}
