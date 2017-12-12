using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class Fearless : AbilityPassive
    {
        public Fearless() : base()
        {
            this.Name = "Fearless";
            this.commonDescription = "For characters with unshakeable courage.  Fearless characters never test for Fear, as they are immune.\n\nFearless costs 4 CP.\n\nWritten as - Fearless -/-.";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 4;
        }
    }
}