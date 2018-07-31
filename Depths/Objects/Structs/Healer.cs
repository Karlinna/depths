using Depths.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Structs
{
    public abstract class Healer : Attacker, IHealer, IHealable
    {
        protected Healer(int health, int mana, bool isD, int healthMax, int baseDamage, double coeff)
            : base (health, mana,  isD,  healthMax,  baseDamage,  coeff)
        {
           
        }


        public void GetHeal(int value, IHealer got)
        {
            if (Health + value > HealthMax) Health = HealthMax;
            else Health += value;
        }

        public void HealOther(IHealable healable, int value)
        {
            healable.GetHeal(value, this);
        }
    }
}
