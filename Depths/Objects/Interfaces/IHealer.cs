﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Interfaces
{
    interface IHealer
    {
        void HealOther(IHealable healable, int value);
    }
}