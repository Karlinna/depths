using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    class NPC : ITalk
    {
        public string Name { get; }

        public NPC(string n)
        {
            Name = n;
        }
    }
}
