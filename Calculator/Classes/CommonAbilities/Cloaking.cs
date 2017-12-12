using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class Cloaking : AbilityPassive
    {
        public Cloaking() : base()
        {
            this.Name = "Cloaking";
            this.commonDescription = "Cloaking is the most powerful form of invisibility available.  A Character with Cloaking begins the game invisible to the opponent.  So long as the " +
                "Character remains more than 1 inch from all opponents, they remain invisible.  If an enemy comes within 1 inch of them, they are revealed.  If the character passes and they " +
                "do not meet the criteria for being spotted, they vanish.  A character cannot disappear the same round in which they were revealed." +
                "\n\nWhile undetected, the Character can perform a surprise attack.  If this Character attacks while invisible, they are revealed.  If they use abilities which do not inflict " +
                "damage and does not target an enemy, the Character remains invisible.  If the character is invisible but moves close enough to reveal themselves, the first ability they use may " +
                "be executed as a surprise attack." +
                "\n\nCloaking costs 4 Character points." +
                "\n\nWritten as - Cloaking -/- (4 points).";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 4;
        }
    }
}