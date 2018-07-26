using Depths.Objects.Dependencies;
using Depths.Objects.Player;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.GameObjects
{
    abstract class Item
    {
        public string Name { get; protected set; }

        public ItemRarity rarity;
        public string FlavorText { get; protected set; }

        protected Stats<AttributeType, int> Stats = new Stats<AttributeType, int>();

        protected Item(string name, ItemRarity rarity, string flavorText)
        {
            Name = name;
            this.rarity = rarity;
            FlavorText = flavorText;
            ItemStructure.Add(this);
        }
        public int GetStatValue(AttributeType at)
        {
            return Stats.GetValueByKey(at);
        }
    }
}
