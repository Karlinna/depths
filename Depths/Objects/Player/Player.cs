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
    public partial class Player : Healer, ITalk, IWearer, IMapCond, ILevalable
    {
   
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

        public override void DamageOther(IAttackable target)
        {
            int damage_val = 0;
            if (PlayerClass == PlayerClass.ROGUE || PlayerClass == PlayerClass.WARRIOR)
                damage_val =(int)(characterSheet.AttackPower * Coeff);
            else damage_val = (int)(characterSheet.SpellPower * Coeff);
            LastDamageDone = damage_val;
            target.GetDamage(LastDamageDone);
            
        }
        public override void GetDamage(int value)
        {
            //Every 10 armor 1%
            double value_d = value;
            int armor = characterSheet.Armor / 10;
            if (Health - (int)value_d <= 0) isD = true;
            else Health -= (int)value_d;

        }
        public override void HealOther(IHealable healable)
        {
            healable.GetHeal((int)(characterSheet.SpellPower * 0.8), this);
        }
        public override void GetHeal(int value, IHealer got)
        {
            HealThis(value);
        }

        public void SetAttributes(int str, int agi, int intellect, int sta)
        {
            characterSheet.Strength = new Attribute(AttributeType.STR, str);
            characterSheet.Agility = new Attribute(AttributeType.AGI, agi);
            characterSheet.Intellect = new Attribute(AttributeType.INT, intellect);
            characterSheet.Stamina = new Attribute(AttributeType.STA, sta);
        }
        public void CalculateByClass()
        {
            characterSheet.Armor = (int)(5 * characterSheet.Strength.Value);
            switch (PlayerClass)
            {
                case PlayerClass.WARRIOR:
                    characterSheet. AttackPower = (int)(characterSheet.Strength.Value * 1.2 + BaseDamage);                   
                    break;
                case PlayerClass.MAGE:
                    characterSheet.SpellPower = (int)(characterSheet.Intellect.Value * 0.9 + BaseDamage);
                    break;
                case PlayerClass.ROGUE:
                    characterSheet.AttackPower = (int)(characterSheet.Agility.Value * 1.1 + BaseDamage);
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
        
        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[PLAYER]");
            sb.AppendLine();
            sb.Append(String.Format("Name:{0}", Name));
            sb.AppendLine();
            sb.Append(String.Format("LocX:{0}", LocX));
            sb.AppendLine();
            sb.Append(String.Format("LocY:{0}", LocY));
            sb.AppendLine();
            sb.Append(String.Format("Class:{0}", Enum.GetName(typeof(PlayerClass),PlayerClass)));
            sb.AppendLine();
            sb.Append(String.Format("Gender:{0}", Enum.GetName(typeof(Gender), Gender)));
            sb.AppendLine();
            sb.Append(String.Format("Image:{0}", image_name));
            sb.AppendLine();
            //sb.Append(String.Format("EquippedItems:{0}", EquippedItems.Save()));
            //sb.AppendLine();
            //sb.Append(String.Format("Backpack:{0}", Backpack.Save()));
            //sb.AppendLine();
            sb.Append(String.Format("Level:{0}", Level));
            sb.AppendLine();
            sb.Append(String.Format("Exp:{0}", Exp));
            sb.AppendLine();
            //sb.Append(String.Format("characterSheet:{0}", characterSheet.Save()));
            //sb.AppendLine();
            sb.Append("[PLAYER]");
            return sb.ToString();
        }
    }
}
