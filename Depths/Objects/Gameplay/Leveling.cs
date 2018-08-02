using Depths.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Gameplay
{
    static class Leveling
    {
        public static void GrantExp(ILevalable il, int value)
        {
            int ilExp = il.Exp;
            int nextLevel = Exp[il.Level - 1];
            if (ilExp + value >= nextLevel) LevelUp(il);
            else il.Exp += value;


        }
        private static void LevelUp(ILevalable il)
        {
            if (il.Level == 10)
            {
                il.Exp = 0;
                return;
            }
            il.Level += 1;
        }
        private static int[] Exp =
        {
            100,
            150,
            300,
            450,
            750,
            1200,
            1950,
            2200,
            4000         


        };

    }
}
