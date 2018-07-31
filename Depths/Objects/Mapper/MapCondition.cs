using Depths.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Mapper
{
    class MapCondition
    {
        IMapCond mapCond;
       
        public bool Exists { get; set; }
        public int StartIndex;
        public int EndIndex;

        public bool ConditionMet(int x, int y)
        {
            return mapCond.LocY == y && mapCond.LocX == x;
           
        }

        public MapCondition(IMapCond mapCond, int si, int ei)
        {
            Exists = true;
            this.mapCond = mapCond;
            StartIndex = si;
            EndIndex = ei;
        }
    }
}
