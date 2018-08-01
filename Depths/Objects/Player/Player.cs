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
        public bool InCombat = false;
        public PlayerClass PlayerClass { get; private set; }
        public Gender Gender { get; }
        public string FormalGreeting = "";

        public string NotFormalGreet = "";
        public string image_name;


        public Attribute Strength { get; private set; }
        public Attribute Agility { get; private set; }
        public Attribute Intellect { get; private set; }
        public Attribute Stamina { get; private set; }

        public int AttackPower { get; private set; }
        public int SpellPower { get; private set; }
        public int Armor { get; private set; }
        public int MagicDefense { get; private set; }

        public string BaseAttackName { get; }
        public string BaseStrongAttackname { get; }


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

            switch (PlayerClass)
            {
                case PlayerClass.WARRIOR:
                    SetAttributes(6, 3, 2, 4);
                    break;
                case PlayerClass.MAGE:
                    SetAttributes(2, 4, 6, 3);
                    break;
                case PlayerClass.ROGUE:
                    SetAttributes(3, 6, 2, 4);
                    break;
                default:
                    break;  
            }
            CalculateByClass();

        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5}", 
                Name, FormalGreeting, Health, BaseDamage, Enum.GetName(typeof(Gender), Gender), Enum.GetName(typeof(PlayerClass) , PlayerClass));
        }


        public override void DamageOther(IAttackable target)
        {
            int damage_val = 0;
            if (PlayerClass == PlayerClass.ROGUE || PlayerClass == PlayerClass.WARRIOR)
                damage_val =(int)(AttackPower * Coeff);
            else damage_val = (int)(SpellPower * Coeff);
            LastDamageDone = damage_val;
            target.GetDamage(LastDamageDone);
            
        }
        public override void GetDamage(int value)
        {
            //Every 10 armor 1%
            double value_d = value;
            int armor = Armor / 10;
            if (Health - (int)value_d <= 0) isD = true;
            else Health -= (int)value_d;

        }
        public override void HealOther(IHealable healable)
        {
            healable.GetHeal((int)(SpellPower * 0.8), this);
        }
        public override void GetHeal(int value, IHealer got)
        {
            HealThis(value);
        }



        public void SetAttributes(int str, int agi, int intellect, int sta)
        {
            Strength = new Attribute(AttributeType.STR, str);
            Agility = new Attribute(AttributeType.AGI, agi);
            Intellect = new Attribute(AttributeType.INT, intellect);
            Stamina = new Attribute(AttributeType.STA, sta);
        }
        public void CalculateByClass()
        {
            Armor = (int)(5 * Strength.Value);
            switch (PlayerClass)
            {
                case PlayerClass.WARRIOR:
                    AttackPower = (int)(Strength.Value * 1.2 + BaseDamage);
                    
                    break;
                case PlayerClass.MAGE:
                    SpellPower = (int)(Intellect.Value * 0.9 + BaseDamage);
                    break;
                case PlayerClass.ROGUE:
                    AttackPower = (int)(Agility.Value * 1.1 + BaseDamage);
                    break;
                default:
                    break;
            }
        }

        public int GetHealthPercentage()
        {
            int perc = 0;
            perc = (int)(((double)Health / (double)HealthMax) * 100);
            return perc;
        }
        
        
    }
}
