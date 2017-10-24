using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class TechEncase : Encase
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
                return "Represents an effect which utterly immobilizes a character by encasing them.  Unlike Encase, this represents an effect produced via technomancy and can only be " +
                    "resisted accordingly.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Tech contest against S. If failed, they are Encased for the duration of the effect. Encased characters are utterly helpless, unable to "+
                    "move, act, or defend themselves.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new Encase());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Tech Encase";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "Tech Encase S/D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                return "Tech Encase " + variables["S"].Value + "/" + variables["D"].Value;
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //TODO This may not be a fair way to get the cost.  Like, is a Strength 5 Encase with a Duration of 2 really as good as a Strength 10 Encase with a Duration of 1?
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            var moddedS = variables["S"].Value + 3;
            return variables["D"].Value * 5 * moddedS;
        }
        
        #endregion
    }
}
