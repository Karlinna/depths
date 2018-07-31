using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    public interface IAttackable
    {
        void GetDamage(int value);
        bool isDead { get; }

        int Health { get; }

        int HealthMax { get; }
    }
}
