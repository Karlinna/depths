using Depths.Objects.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Player
{
    public class Attribute
    {
        private AttributeType Type;
        public int Value { get; private set; }

        public void GainStatsFromItems(Inventory e)
        {
            for (int i = 0; i < e.GetSize(); i++)
            {
               Value +=  e.GetAttributeValue(e[i], Type);
            }
        }
    }
}
