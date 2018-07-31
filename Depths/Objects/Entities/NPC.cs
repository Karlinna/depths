using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    public class NPC : ITalk
    {
        public string Name { get; }
        public Gender gender;

        public NPC(string n, Gender g)
        {
            Name = n;
            gender = g;
        }
    }
}
