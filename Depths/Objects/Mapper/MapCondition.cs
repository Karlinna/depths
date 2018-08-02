using Depths.Objects.Entities;
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
        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[MAPCONDITION]");
            sb.AppendLine();
            sb.Append(String.Format("exists:{0}", Exists));
            sb.AppendLine();
            sb.Append(String.Format("startIndex:{0}", StartIndex));
            sb.AppendLine();
            sb.Append(String.Format("endIndex:{0}",EndIndex));
            sb.AppendLine();
            Enemy e = null;
            Narrator n = null;
            Character c = null;
            if (mapCond is Enemy) e = (Enemy)mapCond;
            else if (mapCond is Narrator) n = (Narrator)mapCond;
            else if (mapCond is Character) c = (Character)mapCond;
            sb.Append(e != null ? e.Save() : n != null ? n.Save() : c.Save());
            sb.AppendLine();
            sb.Append("[MAPCONDITION]");
            return sb.ToString();
        }
    }
}
