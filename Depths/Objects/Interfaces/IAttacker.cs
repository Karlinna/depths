using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    interface IAttacker
    {
        int BaseDamage { get; } //Only phsycal for now

        double Coeff { get; } //For phisycal it's 1.0

        void DamageOther(IAttackable target);
    }
}
