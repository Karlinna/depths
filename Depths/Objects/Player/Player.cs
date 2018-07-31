using Depths.Objects.Dependencies;
using Depths.Objects.GameObjects;
using Depths.Objects.Interfaces;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Player
{
    public class Player : Healer, ITalk, IWearer
    {
        public int LocX;
        public int LocY;
        public string Name { get; private set; }

        public Backpack Backpack = new Backpack(20);
        public Inventory EquippedItems { get; }

        public PlayerClass PlayerClass { get; private set; }
        public Gender Gender { get; }

        public string FormalGreeting = "";
        public string NotFormalGreet = "";

        public string image_name;

        public Player(string name, int health, int mana, bool isD, int healthMax, int baseDamage, double coeff, PlayerClass pc, Gender g)
          : base(health, mana, isD, healthMax, baseDamage, coeff)
        {
            PlayerClass = pc;
            Gender = g;
            Name = name;
        }

        public void PickUp(Item a)
        {
            Backpack.AddItem(a);
        }
        public void Drop(Item a)
        {
            Backpack.Remove(a);
        }

        public void EquipFromBackpack(IWearable i)
        {
            EquippedItems.Equip(i, Backpack);
        }

        public void InitPlayer()
        {
            switch(Gender)
            {
                case Gender.FEMALE:
                    FormalGreeting = "Lady";
                    NotFormalGreet = "Lady";
                    break;
                case Gender.MALE:
                    FormalGreeting = "Mister";
                    NotFormalGreet = "Lad";
                    break;
                case Gender.OTHER:
                    FormalGreeting = "";
                    NotFormalGreet = "";
                    break;

            }
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5}", 
                Name, FormalGreeting, Health, BaseDamage, Enum.GetName(typeof(Gender), Gender), Enum.GetName(typeof(PlayerClass) , PlayerClass));
        }
    }
}
