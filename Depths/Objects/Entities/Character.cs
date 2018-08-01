using Depths.Objects.Interfaces;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    public class Character : ITalk, ICloneable, IMapCond
    {
        public string Name { get; }
        public int LocY { get; set; }
        public int LocX { get ; set; }

        public Gender gender;

        public Character(string n, Gender g)
        {
            Name = n;
            gender = g;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
