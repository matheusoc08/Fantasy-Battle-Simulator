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
        public int Id { get; set; }
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

        public Character(int id, string name, /*int lvl,*/ int hp, int mp, int pAtk, int mAtk, int pDef, int mDef, int critRate)
        {
            this.Id = id;
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

    }    
}
