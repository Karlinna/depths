using Depths.Objects.GameObjects;
using Depths.Objects.Interfaces;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Dependencies
{
    class Inventory
    {
        private List<IWearable> Wearables = new List<IWearable>();


        public void Equip(IWearable iw, Backpack b)
        {
            IWearable item = null;
            item = Wearables.Find(i => iw.GetSlot() == i.GetSlot());
            if(item == null)
            {
                Wearables.Add(iw);
            }
            else
            {
                SwitchItems(item, iw, b);
            }

        }
        public void SwitchItems(IWearable old, IWearable new_, Backpack b)
        {
            b.Switch((Item)old, (Item)new_);

            int oldIndex = Wearables.FindIndex(y => y.GetSlot() == old.GetSlot());
            int newIndex = Wearables.FindIndex(y => y.GetSlot() == new_.GetSlot());

            var c = Wearables[oldIndex];
            Wearables[oldIndex] = Wearables[newIndex];
            Wearables[newIndex] = c;
            
        }
        public int GetAttributeValue(IWearable i, AttributeType at)
        {

            return ((Item)Wearables.Find(y => i == y)).GetStatValue(at);
        }

        public IWearable this[int index]
        {
            get
            {
                return Wearables[index];
            }

        }
        public int GetSize() => Wearables.Count;
    }
}
