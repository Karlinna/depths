using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Interpreter
{
    class NotDefinedCharacterException : Exception
    {

        public NotDefinedCharacterException(string name) : base ("Not defined character: " + name)
        {

        }
 
        
    }
}
