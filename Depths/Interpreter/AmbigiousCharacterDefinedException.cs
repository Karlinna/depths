using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Interpreter
{
    class AmbigiousCharacterDefinedException : Exception
    {
        public AmbigiousCharacterDefinedException(string name) : base ("Ambigious character is defined: " + name)
        {

        }
    }
}
