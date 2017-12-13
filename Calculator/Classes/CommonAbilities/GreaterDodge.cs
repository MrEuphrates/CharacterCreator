using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class GreaterDodge : AbilityPassive
    {
        public GreaterDodge() : base()
        {
            this.Name = "Greater Dodge";
            this.commonDescription = "Especially evasive characters might use this ability, indicating they can evade even ordinarily unavoidable abilities.  When this character dodges an " +
                "attack, they negate NDo.  Note that Greater No Dodge trumps Greater Dodge.  The cost of Greater Dodge is 0.5 CP per Speed." +
                "\n\nWritten as - < Ability Name > -/-  Greater Dodge (< Speed > * 0.5 points).";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {//TODO If a character's stats change, the cost of these abilities also changes, and while the cost calc is handled correctly, it's not shown on the character form.
            if (character == null) return 0;
            return character.Speed * 0.5;
        }
    }
}