using Depths.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Structs
{
    public static class ItemStructure
    {
        private static List<Item> Items = new List<Item>();    
        private static List<Weapon> Weapons = new List<Weapon>();
        

        public static void Add(Item a)
        {
            Items.Add(a);
            if(a is Weapon)      
                Weapons.Add((Weapon)a);
   
        }
        
        public static int GetIndex(Item a)
        {
            return Items.FindIndex(i => a.Name == i.Name);
        }
        
    
    }
}
