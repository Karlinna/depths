using Depths.Objects.Dependencies;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Player
{
    public partial class Player
    {
        public string Name { get; private set; }
        public Backpack Backpack = new Backpack(20);
        public Inventory EquippedItems { get; }
        public bool InCombat = false;
        public PlayerClass PlayerClass { get; private set; }
        public Gender Gender { get; }
        public string FormalGreeting = "";
        public string NotFormalGreet = "";
        public string image_name;
        public CharacterSheet characterSheet = new CharacterSheet();
        public string BaseAttackName { get; }
        public string BaseStrongAttackname { get; }
        public int LocY { get; set; }
        public int LocX { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }

        public Player(string name, int health, int mana, bool isD, int healthMax, int baseDamage, double coeff, PlayerClass pc, Gender g)
          : base(health, mana, isD, healthMax, baseDamage, coeff)
        {
            PlayerClass = pc;
            Gender = g;
            Name = name;
            Level = 1;
            Exp = 0;
        }

    }
}
