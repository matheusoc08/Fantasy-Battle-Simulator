using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator.Class
{
    public abstract class Character
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set; }
        public int CriticalRate { get; set; }
        public int LastHit { get; set; }

        public Character(string name)
        {
            //this.Id = id;
            this.Name = name;
            this.HealthPoints = 100;
            this.ManaPoints = 100;
            this.PhysicalAttack = 100;
            this.MagicAttack = 50;
            this.PhysicalDefense = 20;
            this.MagicDefense = 15;
            this.CriticalRate = 1;
        }

        public string Attack()
        {
            Random dice = new Random();
            LastHit = dice.Next(0, this.PhysicalAttack);
            LastHit += CriticalDamage(this.CriticalRate, LastHit);

            if (LastHit == 0)
            {
                return $"{this.Name} errou o ataque...";
            }
            else
            {
                return $"{this.Name} ataca causando {LastHit} de dano";
            }
        }

        public string Magic()
        {
            Random dice = new Random();
            LastHit = dice.Next(0, this.MagicAttack);
            LastHit += CriticalDamage(this.CriticalRate, LastHit);
            this.ManaPoints -= 20;

            if (LastHit == 0)
            {
                return $"{this.Name} errou o ataque...";
            }
            else
            {
                return $"{this.Name} lançou um feitiço causando {LastHit} de dano";
            }
        }

        public string Defense()
        {
            Random dice = new Random();

            if(dice.Next(0,2) == 1)
            {
                return $"{this.Name} defendeu o ataque";
            }
            else
            {
                return $"{this.Name} não conseguiu defender o ataque";
            }
        }

        public int CriticalDamage(int criticalRate, int LastHit)
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
            if((damage - this.PhysicalDefense) < 0)
            {
                Console.WriteLine($"{this.Name} defendeu o ataque!");
            }
            else
            {
                this.HealthPoints -= damage - this.PhysicalDefense;
            }
        }

        public void TakeMAtk(int damage)
        {
            if ((damage - this.MagicDefense) < 0)
            {
                Console.WriteLine($"{this.Name} defendeu o ataque!");
            }
            else
            {
                this.HealthPoints -= damage - this.MagicDefense;
            }
        }

    }    
}
