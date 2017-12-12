using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class Fleet : AbilityPassive
    {
        public Fleet() : base()
        {
            this.Name = "Fleet";
            this.commonDescription = "Characters’ maximum movement (in inches) is determined by their Speed.  In a turn, a Character may either move normally, run, or sprint." +
                "\n1.) Normal: the character may move a number of inches equal to half their Speed, rounding up." +
                "\n2.) Running: the distance is equal to their Speed, but costs 5 Time." +
                "\n3.) Sprinting: the distance is equal to their Speed plus half their Speed, but costs 10 Time." +
                "\n\nHowever, a Fleet character is one which is especially swift on its feet.  Its movement looks like this:" +
                "\n1.) Normal: the character may move a number of inches equal to their Speed." +
                "\n2.) Running: the distance is equal to their Speed plus half their Speed, which costs 5 Time." +
                "\n3.) Sprinting: the distance is equal to twice their Speed, which costs 10 Time." +
                "\n\nFleet costs 2 Character points." +
                "\n\nWritten as -Fleet -/ -(2 points)";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 2;
        }
    }
}