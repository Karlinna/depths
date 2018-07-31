using Depths.Objects.Interfaces;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    public class Enemy : Attacker, ITalk, IMapCond, ICloneable
    { 
        public string Name { get; }
        public int LocY { get ; set; }
        public int LocX { get ; set; }

        public Enemy(string name, int health, int mana, bool isD, int healthMax,
            int baseDamage, double coeff) : 
            base (health, mana, isD, healthMax,
            baseDamage, coeff)
        {
            Name = name;
        }
        public void InitEnemy(int x, int y)
        {
            LocX = x;
            LocY = y;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
