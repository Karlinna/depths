using Depths.Objects.Dependencies;
using Depths.Objects.Interfaces;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.GameObjects
{
    class Weapon : Item, IWearable
    {
        private delegate void WeaponScript();
        private WeaponScript Script { set; get; }
        public int RangeMin { get; private set; }
        public int RangeMax { get; private set; }
        public int Speed { get; private set; }
        public bool MainHand { get; private set; }
        public bool OffHand { get; private set; }
        public bool TwoHand { get; private set; }

         public Weapon(string name, ItemRarity rarity, string flavorText,
            int rangeMin, int rangeMax, int speed, bool TwoHand, bool MainHand,
            bool OffHand, Stats<AttributeType, int> stats) :
            base (name, rarity, flavorText)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            Speed = speed;
            this.TwoHand = TwoHand;
            Stats = stats;
        }

        public int GetSlot()
        {
            return TwoHand ? Slots.Main_Hand : MainHand ? Slots.Main_Hand : Slots.Off_Hand;
        }

    }
}
