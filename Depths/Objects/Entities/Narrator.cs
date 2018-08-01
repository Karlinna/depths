using Depths.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Entities
{
    class Narrator : ITalk, IMapCond, ICloneable
    {
        public string Name => "Narrator";

        public int LocY { get; set; }
        public int LocX { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
