using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    class Enemy : Attacker, ITalk
    { 
        public string Name { get; }


        protected Enemy(string name, int health, int mana, bool isD, int healthMax,
            int baseDamage, double coeff) : 
            base (health, mana, isD, healthMax,
            baseDamage, coeff)
        {
            Name = name;
        }

    }
}
