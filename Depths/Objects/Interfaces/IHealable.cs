using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Interfaces
{
    public interface IHealable
    {
        void GetHeal(int value, IHealer got);
    }
}
