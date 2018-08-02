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

        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[NARRATOR]");
            sb.AppendLine();
            sb.Append(String.Format("name:{0}", Name));
            sb.AppendLine();
            sb.Append(String.Format("LocX:{0}", LocX));
            sb.AppendLine();
            sb.Append(String.Format("LocY:{0}", LocY));
            sb.AppendLine();
            sb.Append("[NARRATOR]");
            return sb.ToString();
        }
    }
}
