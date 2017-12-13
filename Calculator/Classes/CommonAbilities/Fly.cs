using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.Classes;

namespace Calculator.Classes.CommonAbilities
{
    public class Fly : AbilityPassive
    {
        public Fly() : base()
        {
            this.Name = "Fly";
            this.commonDescription = "Characters with this ability have the option to fly.  Flyers on the ground behave like ordinary characters, but unlike ordinary characters, flyers can elevate " +
                "themselves up to 10 inches off the ground (they must be at least 1 inch off the ground to count as flying)." +
                "\n\nFlying versus Non - Flying" +
                "\n1.) At the end of the round, if a flyer’s health is at or below 25 % of maximum, they must pass a Might test to continue flying.If they fail, they immediately plummet to the " +
                "ground and cannot fly until their health is above 25 %." +
                "\n2.) If the flyer flew at any point during the current round, it does not recharge energy at the end of the round." +
                "\n\nMovement" +
                "\n1.) While flying, a character’s movement speed is upgraded to Fleet.  If they are already Fleet, it is upgraded to Super." +
                "\n2.) Flyers move horizontally and vertically normally.  They may descend any number of inches without consuming movement." +
                "\n\nDefense" +
                "\n1.) Flyers add + 2 Speed for purposes of dodging, and + 2 Strength and Marksmanship for deflecting.  These bonuses do not apply versus flying enemies." +
                "\n\nFly costs 5 Character points.  Flyers may choose to ignore the penalty of not receiving a recharge while flying, an ability which costs an additional 2 CP.  Flyers may also " +
                "choose to be capable of flight regardless of damage suffered, an ability which costs 1 additional CP." +
                "\n\nWritten as - Fly -/- (5 points).";
            this.InputDescription = "(" + getCharacterPointCost(null) + " points)";
            this.isCommon = true;
        }
        public override double getCharacterPointCost(Character character)
        {
            return 5;
        }
    }
}