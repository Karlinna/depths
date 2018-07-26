using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Structs
{
    abstract class Attacker : IAttackable, IAttacker
    {
        public int Health { protected set; get; }
        public int Mana { protected set; get; }
        public bool isD = false;
        public int HealthMax { protected set; get; }
        public bool isDead
        {
            get
            {
                return isD;
            }

        }

        protected Attacker(int health, int mana, bool isD, int healthMax, int baseDamage, double coeff)
        {
            Health = health;
            Mana = mana;
            this.isD = isD;
            HealthMax = healthMax;
            BaseDamage = baseDamage;
            Coeff = coeff;
        }

        public int BaseDamage { protected set; get; }

        public double Coeff { protected set; get; }

        public void GetDamage(int value)
        {
            if (Health - value <= 0) isD = true;
            else Health -= value;

        }

        public void HealThis(int value)
        {
            if (value + Health > HealthMax)
            {
                Health = HealthMax;
            }
            else
            {
                Health += value;
            }
        }

        public void DamageOther(IAttackable target)
        {
            target.GetDamage((int)((double)BaseDamage * Coeff));
        }

    }
}
