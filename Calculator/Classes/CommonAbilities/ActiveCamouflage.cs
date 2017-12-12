using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class ActiveCamouflage : AbilityPassive
    {
        public ActiveCamouflage() : base()
        {
            this.Name = "Active Camouflage";
            this.commonDescription = "Active camouflage is an advanced form of camouflage, removing most of the issues ordinary camouflage posed.  A Character with Active Camouflage begins the " +
                "game invisible to the opponent.  So long as the Character remains more than 5 inches from all opponents, they remain invisible.  If an enemy comes within 5 inches of them, " +
                "they are revealed.  If the character passes and they do not meet the criteria for being spotted, they vanish.  A character cannot disappear the same round in which they were " +
                "revealed.\n\nWhile undetected, the Character can perform a surprise attack.  If this Character attacks while invisible, they are revealed.If they use abilities which do not " +
                "inflict damage and do not target an enemy, the Character remains invisible.  If the character is invisible but moves close enough to reveal themselves, the first ability they " +
                "use may be executed as a surprise attack.\n\nActive Camouflage costs 2 Character points.\n\nWritten as: - Active Camouflage -/- (2 points).";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 2;
        }
    }
}