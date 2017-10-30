using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class Encase : SpecialRule
    {
        #region Properties
        public override int CalculationOrder
        {
            get
            {
                return 0;
            }
        }

        public override string Description
        {
            get
            {
                return "Represents an effect which utterly immobilizes a character by encasing them. Examples: a frost attack that freezes the target solid; a tar-like substance which "+
                    "coats and hardens around the target, rendering them totally immobile.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Strength contest against S. If failed, they are Encased for the duration of the effect. Encased characters are utterly helpless, unable to "+
                    "move, act, or defend themselves.";
            }
        }

        protected override List<SpecialRule> IncompatibleRules
        {
            get
            {
                return new List<SpecialRule>();
            }
        }

        public override string Name
        {
            get
            {
                return "Encase";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "This effect lasts D rounds; however, the duration can be reduced. If the remaining time is reduced below 1, the effect ends immediately. Environments hostile to the " +
                    "nature of this effect, such as using Freeze in a Desert, cut this duration in half; whereas those friendly to it, such as Freeze in a Tundra, double the duration." +
                    "\n\nSimilarly, encased characters affected by abilities hostile to this effect (such as a Fire attack against a Frozen character) will immediately reduce the duration " +
                    "of the effect by 1 round, negating the effect if the duration is reduced below 1.  Abilities friendly to the effect do not extend the duration." +
                    "\n\nFor every 50 damage this character suffers (before Armor or Toughness), the duration of this effect is reduced by 1." +
                    "\n\nEncase does not stack, but if the same form of Encase affects the character (such as a Freeze ability affecting a Frozen character), the greater duration becomes the " +
                    "new duration.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Encase S/D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Encase " + variables["S"].Value + "/" + variables["D"].Value;
            }
        }

        public override SerializableDictionary<string, SpecialRuleVariable> Variables
        {
            get
            {
                if(variables == null)
                {
                    variables = new SerializableDictionary<string, SpecialRuleVariable>();
                    var srv = new Duration("D");
                    variables.Add(srv.Variable, srv);
                    var srv2 = new MaxTen("S");
                    variables.Add(srv2.Variable, srv2);
                }
                return variables;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //TODO This may not be a fair way to get the cost.  Like, is a Strength 5 Encase with a Duration of 2 really as good as a Strength 10 Encase with a Duration of 1?
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["D"].Value * 5 * variables["S"].Value;
        }

        public override string howIsEnergyCostCalculated()
        {
            return "5 x D x S";
        }

        #endregion
    }
}
