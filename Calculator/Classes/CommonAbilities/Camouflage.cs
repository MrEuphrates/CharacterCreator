using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class Camouflage : AbilityPassive
    {
        public Camouflage() : base()
        {
            this.Name = "Camouflage";
            this.commonDescription = "Characters wearing camouflage are exceptionally difficult to spot from all but the closest distances.  A Character with Camouflage begins the game invisible " +
                "to the opponent.  So long as the Character remains more than 10 inches from all opponents, they remain invisible.  If an enemy comes within 10 inches of them but is further " +
                "than 1 inch away, if they did not move this or last round, they remain undetected.  If an enemy passes within 1 inch of them, they are revealed.  If the character passes and " +
                "they do not meet the criteria for being spotted, they vanish.  A character cannot disappear the same round in which they were revealed." +
                "\n\nWhile undetected, the Character can perform a surprise attack.  If this Character attacks while invisible, they are revealed.  If they use abilities which do not inflict " +
                "damage and does not target an enemy, the Character remains invisible.  If the character is invisible but moves close enough to reveal themselves, the first ability they use may " +
                "be executed as a surprise attack." +
                "\n\nCamouflage costs 1 Character point." +
                "\n\nWritten as - Camouflage -/- (1 point).";
            this.InputDescription = "(" + getCharacterPointCost(null) + " point)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 1;
        }
    }
}