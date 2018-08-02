using Depths.Objects.Player;

namespace Depths.Objects.Structs
{
    public class CharacterSheet
    {

        public Attribute Strength { get; set; }
        public Attribute Agility { get;  set; }
        public Attribute Intellect { get;  set; }
        public Attribute Stamina { get;  set; }

        public int AttackPower { get;  set; }
        public int SpellPower { get;  set; }
        public int Armor { get;  set; }
        public int MagicDefense { get;  set; }

        internal object Save()
        {
            return "sheet";

        }
    }
}
