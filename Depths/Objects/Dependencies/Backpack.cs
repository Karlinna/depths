using Depths.Objects.GameObjects;
using Depths.Objects.Interfaces;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Dependencies
{
    public class Backpack
    {
        public int Capacity { get; set; }
        private List<Item> Items = new List<Item>();

        public void Switch(Item a, Item b)
        {
            int static_index_a = ItemStructure.GetIndex(a);
            int static_index_b = ItemStructure.GetIndex(b);

            int getA = Items.FindIndex(y => ItemStructure.GetIndex(y) == static_index_a);
            int getB = Items.FindIndex(y => ItemStructure.GetIndex(y) == static_index_b);

            var _a_ = Items[getA];
            Items[getA] = Items[getB];
            Items[getB] = _a_;
        }

        public void AddItem(Item a)
        {
            if (Items.Count < Capacity) Items.Add(a);
            else a = null; //Full Backpack
        }

        public Item this[int index]
        {
            get { return Items[index]; }
        }
        public Backpack(int cap)
        {
            Capacity = cap;
        }
        public void Remove(Item a)
        {
            int static_index_a = ItemStructure.GetIndex(a);
            int getA = Items.FindIndex(y => ItemStructure.GetIndex(y) == static_index_a);

            Items.Remove(Items[getA]);
        }

        internal object Save()
        {
            throw new NotImplementedException();
        }
    }
}
