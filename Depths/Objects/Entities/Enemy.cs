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

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ENEMY]");
            sb.AppendLine();
            sb.Append(String.Format("name:{0}", Name));
            sb.AppendLine();
            sb.Append(String.Format("LocX:{0}", LocX));
            sb.AppendLine();
            sb.Append(String.Format("LocY:{0}", LocY));
            sb.AppendLine();
            sb.Append("[ENEMY]");
            return sb.ToString();
        }
    }
}
