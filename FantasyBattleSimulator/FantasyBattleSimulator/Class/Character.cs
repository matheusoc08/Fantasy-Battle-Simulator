using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    public /*abstract*/ class Character
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        //public int Level { get; set; }
        public int ManaPoints { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public int CriticalRate { get; set; }
        public int LastHit { get; set; }

        public Character(string name)
        {
            this.Name = name;
            //this.Level = 1;
            this.HealthPoints = 500;
            this.ManaPoints = 100;
            this.PhysicalAttack = 100;
            this.MagicAttack = 50;
            this.PhysicalDefense = 20;
            this.MagicDefense = 15;
            this.CriticalRate = 1;
        }

        public Character(string name, /*int lvl,*/ int hp, int mp, int pAtk, int mAtk, int pDef, int mDef, int critRate)
        {
            this.Name = name;
            //this.Level = lvl;
            this.HealthPoints = hp;
            this.ManaPoints = mp;
            this.PhysicalAttack = pAtk;
            this.MagicAttack = mAtk;
            this.PhysicalDefense = pDef;
            this.MagicDefense = mDef;
            this.CriticalRate = critRate;
        }

        public int Attack()
        {
            Random dice = new Random();
            this.LastHit = dice.Next(0, this.PhysicalAttack);
            this.LastHit += CriticalDamage(this.CriticalRate, this.LastHit);

            Console.WriteLine($"{this.Name} avançou para o ataque.");

            return this.LastHit;
        }

        public int Magic()
        {
            if(this.ManaPoints < 20)
            {
                Console.WriteLine($"{this.Name} não possui mana suficiente para lançar uma magia!");
                this.LastHit = -1;
            }
            else{
                Random dice = new Random();
                this.LastHit = dice.Next(0, this.MagicAttack);
                this.LastHit += CriticalDamage(this.CriticalRate, LastHit);
                this.ManaPoints -= 20;

                Console.WriteLine($"{this.Name} lançou um ataque mágico.");
            }

            return this.LastHit;
        }

        //public string Defense()
        //{
        //    Random dice = new Random();

        //    if(dice.Next(0,2) == 1)
        //    {
        //        return $"{this.Name} defendeu o ataque";
        //    }
        //    else
        //    {
        //        return $"{this.Name} não conseguiu defender o ataque";
        //    }
        //}

        public int CriticalDamage(int criticalRate, int lastHit)
        {
            Random dice = new Random();
            double amplifier = 0.5;
            double criticalDamage = 0;

            if (dice.Next(0, 100) <= criticalRate)
            {
                criticalDamage = LastHit * amplifier;
                Console.WriteLine($"{this.Name} fortaleceu o ataque! (Crítico)");
            }
            return Convert.ToInt32(criticalDamage);
        }

        public override string ToString()
        {
            string retorno = $"Nome: {this.Name}" + Environment.NewLine;
            retorno += $"HP: {this.HealthPoints}" + Environment.NewLine;
            retorno += $"MP: {this.ManaPoints}" + Environment.NewLine;
            retorno += $"Ataque físico: {this.PhysicalAttack}" + Environment.NewLine;
            retorno += $"Defesa física: {this.PhysicalDefense}" + Environment.NewLine;
            retorno += $"Ataque mágico: {this.MagicAttack}" + Environment.NewLine;
            retorno += $"Defesa mágica: {this.MagicDefense}" + Environment.NewLine;
            retorno += $"Chance de crítico: {this.CriticalRate}%" + Environment.NewLine;

            return retorno;
        }

        public void TakePAtk(int damage)
        {
            damage -= this.PhysicalDefense;

            if ((damage) <= 0)
            {
                Console.WriteLine($"{this.Name} defendeu o ataque!");
            }
            else
            {
                Console.WriteLine($"{this.Name} recebeu {damage} de dano físico");
                this.HealthPoints -= damage;
            }
        }

        public void TakeMAtk(int damage)
        {
            if (damage == -1)
                return;

            damage -= this.MagicDefense;

            if (damage <= 0)
            {
                Console.WriteLine($"{this.Name} defendeu o ataque!");
            }
            else
            {
                Console.WriteLine($"{this.Name} recebeu {damage} de dano mágico");
                this.HealthPoints -= damage;
            }
        }

    }    
}
