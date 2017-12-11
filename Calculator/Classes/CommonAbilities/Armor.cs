using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes.CommonAbilities
{
    public class Armor : AbilityPassive
    {
        public Armor()
        {
            this.Name = "Armor";
            this.InputDescription = "Wearing armor is a basic method of protecting oneself.  In Conflict, this is represented by reducing damage by a fixed percentage.  Typically, a character " +
                "can wear armor which reduces damage by up to 50%.  Armor frequently comes with additional properties.\n\nThe Damage Reduction of armor must be a multiple of 10 and cannot " +
                "exceed 50.  For every 10 % of damage reduction provided by Armor, it costs 0.5 Character Points.  This armor is called Personal Armor.  There are limitations on how much armor " +
                "a character can have, based on their stats and abilities:" +
                "\nArmor\tMaximum Speed\tMinimum Strength\tCan Fly" +
                "\n10%\t10\t\t2\t\tYes" +
                "\n20%\t9\t\t3\t\tYes" +
                "\n30%\t8\t\t4\t\tNo" +
                "\n40%\t7\t\t5\t\tNo" +
                "\n50%\t6\t\t6\t\tNo" +
                "\n\nThese limitations can be violated, but at the price of 0.5 Character points per point of violation.  So, if a Speed 8, Strength 4 Character with the ability to fly takes " +
                "40% armor, the cost to them is 4 + 0.5 + 0.5 + 1 = 6 Character Points (2 for the 40% armor, 0.5 for having 1 too much Speed, 0.5 for having 1 too little Strength, and 1 for " +
                "being able to fly when the highest armor allowed is 20%)." +
                "\n\nSmart Armor" +
                "\nIn addition to ordinary personal armor, some characters might wear Smart Armor.  This armor is normally worn underneath or woven into the main armor.  Smart Armor works like " +
                "ordinary armor, but with some differences:" +
                "\n1.) The damage reduction of the smart armor cannot exceed that of the ordinary armor." +
                "\n2.) Smart Armor is not affected by No Armor Reduction, but it is reduced by Armor Buster and it does not provide additional damage reduction: it is only used when the " +
                "ordinary armor is negated." +
                "\n3.) Smart Armor does not count against nor observe the limitations in the table above." +
                "\n4.) Smart Armor costs 0.5 Character Points per 10% damage reduction." +
                "Written as - <Name of Armor> -/- <Percent> Armor.  <Qualifiers, such as ability to Fly when normally not allowed> (<Character Points>).";
            this.CharacterPoints = 2;
            this.isCommon = true;
        }
    }
}